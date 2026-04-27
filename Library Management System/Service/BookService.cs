using Library_Management_System.DB;
using Library_Management_System.DB.Model;
using Library_Management_System.Model;
using Library_Management_System.Model.Request;
using Library_Management_System.Model.Respond;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Service
{
    public class BookService : IBookService
    {
        private readonly LibraryDbContext _context;

        public BookService(LibraryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BooksRespond>> GetBooksAsync()
        {
            return await _context.Books
                .Select(b => new BooksRespond(b.Id, b.Title, b.Author, b.ISBN, b.PublishedYear, b.IsAvailable))
                .ToListAsync();
        }

        public async Task<BooksRespond?> GetBookByIdAsync(int id)
        {
            return await _context.Books
                .Where(b => b.Id == id)
                .Select(b => new BooksRespond(b.Id, b.Title, b.Author, b.ISBN, b.PublishedYear, b.IsAvailable))
                .FirstOrDefaultAsync();
        }

        public async Task<BooksRespond> CreateBookAsync(CreateBookRequest request)
        {
            var book = new DBBook
            {
                Title = request.Title,
                Author = request.Author,
                ISBN = request.ISBN,
                PublishedYear = request.PublishedYear,
                IsAvailable = true
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return new BooksRespond(book.Id, book.Title, book.Author, book.ISBN, book.PublishedYear, book.IsAvailable);
        }

        public async Task<bool> UpdateBookAsync(int id, UpdateBookRequest request)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return false;

            book.Title = request.Title;
            book.Author = request.Author;
            book.ISBN = request.ISBN;
            book.PublishedYear = request.PublishedYear;
            book.IsAvailable = request.IsAvailable;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
                return false;

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
