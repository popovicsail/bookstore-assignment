using System.Linq.Dynamic.Core;
using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Bookstore.Infrastructure.Data;
using Bookstore.Domain.Interfaces;
using Bookstore.Domain.Common;

namespace Bookstore.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BookstoreDbContext _context;

    public BookRepository(BookstoreDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Book>> GetAllAsync(string orderBy)
    {
        IQueryable<Book> query = _context.Books;

        query = query
            .Include(b => b.Author)
            .Include(b => b.Publisher);

        query = query
            .OrderBy(orderBy);

        var books = await query.ToListAsync();

        return books;
    }

    public async Task<PaginatedList<Book>> GetPagedAsync(
        int currentPage,
        int pageSize,
        string orderBy,
        string? Title,
        int? AuthorId,
        string? AuthorFullName,
        DateTime? AuthorDateOfBirthFrom,
        DateTime? AuthorDateOfBirthTo,
        DateTime? PublishedDateTo,
        DateTime? PublishedDateFrom
        )
    {
        IQueryable<Book> query = _context.Books;

        query = query
            .Include(b => b.Author)
            .Include(b => b.Publisher);

        if (!string.IsNullOrEmpty(Title))
        {
            query = query.Where(b => b.Title.ToLower().Contains(Title.ToLower()));
        }
        if (PublishedDateFrom != null)
        {
            query = query.Where(b => b.PublishedDate >= PublishedDateFrom);
        }

        if (PublishedDateTo != null)
        {
            query = query.Where(b => b.PublishedDate <= PublishedDateTo);
        }

        if (!string.IsNullOrEmpty(AuthorFullName))
        {
            query = query.Where(b => b.Author.FullName.ToLower().Contains(AuthorFullName.ToLower()));
        }

        if (AuthorId != null)
        {
            query = query.Where(b => b.AuthorId == AuthorId);
        }
        if (AuthorDateOfBirthFrom != null)
        {
            query = query.Where(b => b.Author.DateOfBirth >= AuthorDateOfBirthFrom);
        }

        if (AuthorDateOfBirthTo != null)
        {
            query = query.Where(b => b.Author.DateOfBirth <= AuthorDateOfBirthTo);
        }

        int count = await query.CountAsync();   

        query = query
            .OrderBy(orderBy);

        query = query
            .Skip((currentPage - 1) * pageSize)
            .Take(pageSize);

        var books = await query.ToListAsync();

        var paginatedBooks = new PaginatedList<Book>(books, currentPage, pageSize, count);

        return paginatedBooks;
    }

    public async Task<Book?> GetByIdAsync(int id)
    {
        IQueryable<Book> query = _context.Books;

        query = query
            .Include(b => b.Author)
            .Include(b => b.Publisher);

        var book = await query.FirstOrDefaultAsync(b => b.Id == id);

        return book;
    }

    public void Add(Book book)
    {
        _context.Books.Add(book);
    }

    public void Update(Book book)
    {
        _context.Books.Update(book);
    }

    public void Delete(Book book)
    {
         _context.Books.Remove(book);
    }
}