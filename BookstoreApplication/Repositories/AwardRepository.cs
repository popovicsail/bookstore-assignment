using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookstoreApplication.Repositories
{
    public class AwardRepository : IAwardRepository
    {
        private readonly BookstoreDbContext _context;

        public AwardRepository(BookstoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Award>> GetAllAsync()
        {
            return await _context.Awards.ToListAsync();
        }

        public async Task<Award?> GetByIdAsync(int id)
        {
            return await _context.Awards.FindAsync(id);
        }

        public async Task AddAsync(Award award)
        {
            await _context.Awards.AddAsync(award);
        }

        public async void Update(Award award)
        {
            _context.Awards.Update(award);
            await _context.SaveChangesAsync();
        }

        public async void Delete(Award award)
        {
            _context.Awards.Remove(award);
            await _context.SaveChangesAsync();
        }
    }
}