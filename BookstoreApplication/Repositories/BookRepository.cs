using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookstoreApplication.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookstoreDbContext _context;

        public BookRepository(BookstoreDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
        }

        public async void Update(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async void Delete(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }
}