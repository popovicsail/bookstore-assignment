using BookstoreApplication.Models;

public interface IPublisherRepository
{
    Task<IEnumerable<Publisher>> GetAllAsync();
    Task<Publisher?> GetByIdAsync(int id);
    Task AddAsync(Publisher publisher);
    void Update(Publisher publisher);
    void Delete(Publisher publisher);
    Task<int> SaveChangesAsync();
}