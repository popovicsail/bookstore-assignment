using Authorstore.Infrastructure.Repositories;
using Bookstore.Domain.Interfaces;
using Bookstore.Infrastructure.Data;
using Bookstore.Infrastructure.Repositories;
using Publisherstore.Infrastructure.Repositories;

namespace Bookstore.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private readonly BookstoreDbContext _context;

    public IBookRepository Books { get; private set; }
    public IAuthorRepository Authors { get; private set; }
    public IPublisherRepository Publishers { get; private set; }

    public UnitOfWork(BookstoreDbContext context)
    {
        _context = context;
        Books = new BookRepository(_context);
        Authors = new AuthorRepository(_context);
        Publishers = new PublisherRepository(_context);     
    }

    public Task<int> CompleteAsync()
    {
        return _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
