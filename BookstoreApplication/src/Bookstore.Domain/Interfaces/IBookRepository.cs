using Bookstore.Domain.Common;
using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetAllAsync(string orderBy);
    Task<PaginatedList<Book>> GetPagedAsync(
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
        );
    Task<Book?> GetByIdAsync(int id);
    void Add(Book book);
    void Update(Book book);
    void Delete(Book book);
}