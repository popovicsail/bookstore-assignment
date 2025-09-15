using BookstoreApplication.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookstoreApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherRepository _publisherRepository;
        public PublishersController(IPublisherRepository publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var publishers = await _publisherRepository.GetAllAsync();

            return Ok(publishers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var publisher = await _publisherRepository.GetByIdAsync(id);

            return Ok(publisher);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Publisher publisher)
        {
            await _publisherRepository.AddAsync(publisher);

            return Ok(publisher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Publisher publisher)
        {
            _publisherRepository.Update(publisher);
            _publisherRepository.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var publisher = await _publisherRepository.GetByIdAsync(id);
            _publisherRepository.Delete(publisher);
            await _publisherRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
