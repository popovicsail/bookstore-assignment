using BookstoreApplication.Models;

public interface IAwardRepository
{
    Task<IEnumerable<Award>> GetAllAsync();
    Task<Award?> GetByIdAsync(int id);
    Task AddAsync(Award award);
    void Update(Award award);
    void Delete(Award award);
    Task<int> SaveChangesAsync();
}