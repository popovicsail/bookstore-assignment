using System.Linq.Dynamic.Core;
using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Bookstore.Infrastructure.Data;
using Bookstore.Domain.Interfaces;
using Bookstore.Domain.Common;

namespace Publisherstore.Infrastructure.Repositories;

public class PublisherRepository : IPublisherRepository
{
    private readonly BookstoreDbContext _context;

    public PublisherRepository(BookstoreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Publisher>> GetAllAsync(string orderBy)
    {
        IQueryable<Publisher> query = _context.Publishers;

        query = query
            .OrderBy(orderBy);

        var publishers = await query.ToListAsync();

        return publishers;
    }

    public async Task<PaginatedList<Publisher>> GetPagedAsync(int currentPage, int pageSize, string orderBy)
    {
        IQueryable<Publisher> query = _context.Publishers;

        //Filtere cu staviti ovde

        int count = await query.CountAsync();

        query = query
            .OrderBy(orderBy);

        query = query
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize);

        var publishers = await query.ToListAsync();

        var paginatedPublishers = new PaginatedList<Publisher>(publishers, currentPage, pageSize, count);

        return paginatedPublishers;
    }

    public async Task<Publisher?> GetByIdAsync(int id)
    {
        IQueryable<Publisher> query = _context.Publishers;

        var publisher = await query.FirstOrDefaultAsync(b => b.Id == id);

        return publisher;
    }

    public void Add(Publisher publisher)
    {
        _context.Publishers.Add(publisher);
    }

    public void Update(Publisher publisher)
    {
        _context.Publishers.Update(publisher);
    }

    public void Delete(Publisher publisher)
    {
         _context.Publishers.Remove(publisher);
    }
}