using Karkathamizha.API.IService;
using Karkathamizha.API.Model;
using Karkathamizha.API.Service.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Karkathamizha.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        #region Add Books
        [HttpPost()]
        [Route("AddBook")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Book>> AddBook(Book book, int id)
        {
            if (book is null)
            {
                Log.Error("Book sent from client is null.");
                return BadRequest("Book object is null");
            }
            if (!ModelState.IsValid)
            {
                Log.Error("Invalid Book object sent from client.");
                return BadRequest("Invalid model object");
            }

            int bookId = await _bookService.AddUpdateBook(book);
            if (bookId == -2)
                return Ok($"Book = {book.BookName} already exists.");
            if (bookId >= 0)
                return Ok($"Book Id = {bookId} updated successfullly.");
            else
                return Ok($"New Book Id = {id} Created successfullly.");
        }
        #endregion

        #region Delete Books
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<string>> DeleteBook(int id)
        {
            var book = await _bookService.GetBookById(id);
            if (book == null)
                return NotFound($"User Id = {id} doesn't exist.");

            var result = await _bookService.DeleteBook(id);
            return Ok(result);
        }
        #endregion

        #region Get All Books
        [HttpGet()]
        [Route("GetAllBooks")]
        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookService.GetAllBooks();
        }
        #endregion

        #region Get Book By Id
        [HttpGet()]
        [Route("GetBookById")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Book))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var book = await _bookService.GetBookById(id);
            if (book == null)
                return NotFound($"Book Id = {id} doesn't exist.");
            return Ok(book);
        }
        #endregion

        #region Get All Books
        [HttpGet()]
        [Route("GetAllBooksWithAuthor")]
        public async Task<IEnumerable<Book>> GetAllBooksWithAuthor()
        {
            return await _bookService.GetAllBooksWithAuthor();
        }
        #endregion
    }
}
