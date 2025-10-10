using Bookstore.Domain.Common;
using Bookstore.Domain.Entities;

namespace Bookstore.Domain.Interfaces;

public interface IPublisherRepository
{
    Task<IEnumerable<Publisher>> GetAllAsync(string orderBy);
    Task<PaginatedList<Publisher>> GetPagedAsync(int currentPage, int pageSize, string orderBy);
    Task<Publisher?> GetByIdAsync(int id);
    void Add(Publisher publisher);
    void Update(Publisher publisher);
    void Delete(Publisher publisher);
}