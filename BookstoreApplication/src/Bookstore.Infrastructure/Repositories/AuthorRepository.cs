using System.Linq.Dynamic.Core;
using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Bookstore.Infrastructure.Data;
using Bookstore.Domain.Interfaces;
using Bookstore.Domain.Common;

namespace Authorstore.Infrastructure.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly BookstoreDbContext _context;

    public AuthorRepository(BookstoreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Author>> GetAllAsync(string orderBy)
    {
        IQueryable<Author> query = _context.Authors;

        query = query
            .OrderBy(orderBy);

        var authors = await query.ToListAsync();

        return authors;
    }

    public async Task<PaginatedList<Author>> GetPagedAsync(int currentPage, int pageSize, string orderBy)
    {
        IQueryable<Author> query = _context.Authors;

        //Filtere cu staviti ovde

        int count = await query.CountAsync();

        query = query
            .OrderBy(orderBy);

        query = query
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize);

        var authors = await query.ToListAsync();

        var paginatedAuthors = new PaginatedList<Author>(authors, currentPage, pageSize, count);

        return paginatedAuthors;
    }

    public async Task<Author?> GetByIdAsync(int id)
    {
        IQueryable<Author> query = _context.Authors;

        var author = await query.FirstOrDefaultAsync(b => b.Id == id);

        return author;
    }

    public void Add(Author author)
    {
        _context.Authors.Add(author);
    }

    public void Update(Author author)
    {
        _context.Authors.Update(author);
    }

    public void Delete(Author author)
    {
         _context.Authors.Remove(author);
    }
}