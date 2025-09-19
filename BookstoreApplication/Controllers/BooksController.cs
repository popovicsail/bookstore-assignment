using BookstoreApplication.Dtos;
using BookstoreApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]  
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDetailDto>>> GetAllBooks()
        {
            var booksFromDb = await _bookRepository.GetAllAsync();

            var booksDto = booksFromDb.Select(book => new BookDetailDto
            {
                Id = book.Id,
                Title = book.Title,
                PageCount = book.PageCount,
                ISBN = book.ISBN,
                PublishedDate = book.PublishedDate.ToString("yyyy-MM-dd"),
                Author = new AuthorDto { Id = book.Author.Id, FullName = book.Author.FullName },
                Publisher = new PublisherDto { Id = book.Publisher.Id, Name = book.Publisher.Name }
            });

            return Ok(booksDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDetailDto>> GetBookById(int id)
        {
            var bookFromDb = await _bookRepository.GetByIdAsync(id);

            if (bookFromDb == null)
            {
                return NotFound();
            }

            var bookDto = new BookDetailDto
            {
                Id = bookFromDb.Id,
                Title = bookFromDb.Title,
                PageCount = bookFromDb.PageCount,
                ISBN = bookFromDb.ISBN,
                PublishedDate = bookFromDb.PublishedDate.ToString("yyyy-MM-dd"),
                Author = new AuthorDto { Id = bookFromDb.Author.Id, FullName = bookFromDb.Author.FullName },
                Publisher = new PublisherDto { Id = bookFromDb.Publisher.Id, Name = bookFromDb.Publisher.Name }
            };

            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {
            await _bookRepository.AddAsync(book);

            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Book book)
        {
            _bookRepository.Update(book);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            _bookRepository.Delete(book);

            return NoContent();
        }
    }
}
