using Library_Management_System.Model.Request;
using Library_Management_System.Service;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        [Route("GetBooks")]
        public async Task<IActionResult> GetBooks()
        {
            var books = await _bookService.GetBooksAsync();
            return Ok(books);
        }

        [HttpGet]
        [Route("GetBookById")]
        public async Task<IActionResult> GetBook([FromBody] GetBookRequest id)
        {
            var book = await _bookService.GetBookByIdAsync(id.BookId);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpPost]
        [Route("CreateBook")]
        public async Task<IActionResult> CreateBook([FromBody] CreateBookRequest request)
        {
            var book = await _bookService.CreateBookAsync(request);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut]
        [Route("UpdateBook/{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] UpdateBookRequest request)
        {
            var result = await _bookService.UpdateBookAsync(id, request);

            if (!result)
                return NotFound();

            return Ok();
        }

        [HttpDelete]
        [Route("DeleteBookById")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBookAsync(id);

            if (!result)
                return NotFound();

            return Ok();
        }
    }
}
