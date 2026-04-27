using Library_Management_System.Model.Request;
using Library_Management_System.Model.Respond;

namespace Library_Management_System.Service
{
    public interface IBookService
    {
        Task<IEnumerable<BooksRespond>> GetBooksAsync();
        Task<BooksRespond?> GetBookByIdAsync(int id);
        Task<BooksRespond> CreateBookAsync(CreateBookRequest request);
        Task<bool> UpdateBookAsync(int id, UpdateBookRequest request);
        Task<bool> DeleteBookAsync(int id);
    }
}
