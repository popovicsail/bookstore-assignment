using BookstoreApplication.Data;
using BookstoreApplication.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var books = await _bookRepository.GetAllAsync();

            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);

            return Ok(book);
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
            _bookRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            _bookRepository.Delete(book);
            await _bookRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
