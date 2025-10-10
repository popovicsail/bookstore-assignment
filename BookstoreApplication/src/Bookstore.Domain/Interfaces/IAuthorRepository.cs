using Bookstore.Domain.Common;
using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Interfaces;

public interface IAuthorRepository
{
    Task<IEnumerable<Author>> GetAllAsync(string orderBy);
    Task<PaginatedList<Author>> GetPagedAsync(int currentPage, int pageSize, string orderBy);
    Task<Author?> GetByIdAsync(int id);
    void Add(Author author);
    void Update(Author author);
    void Delete(Author author);
}