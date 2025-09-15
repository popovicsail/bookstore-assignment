using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookstoreApplication.Repositories
{
    public class PublisherRepository : IPublisherRepository
    {
        private readonly BookstoreDbContext _context;

        public PublisherRepository(BookstoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            return await _context.Publishers.ToListAsync();
        }

        public async Task<Publisher?> GetByIdAsync(int id)
        {
            return await _context.Publishers.FindAsync(id);
        }

        public async Task AddAsync(Publisher publisher)
        {
            await _context.Publishers.AddAsync(publisher);
        }

        public void Update(Publisher publisher)
        {
            _context.Publishers.Update(publisher);
        }

        public void Delete(Publisher publisher)
        {
            _context.Publishers.Remove(publisher);
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}