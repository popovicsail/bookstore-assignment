using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorRepository _authorRepository;
        public AuthorsController(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var authors = await _authorRepository.GetAllAsync();

            return Ok(authors);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);

            return Ok(author);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Author author)
        {
            await _authorRepository.AddAsync(author);

            return Ok(author);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Author author)
        {
            _authorRepository.Update(author);
            _authorRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            _authorRepository.Delete(author);
            await _authorRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
