namespace Bookstore.Domain.Interfaces;

public interface IUnitOfWork : IDisposable //Nisam siguran zasto je IDisposable koristan za sada.
{
    IBookRepository Books { get; }
    IAuthorRepository Authors { get; }
    IPublisherRepository Publishers { get; }
    Task<int> CompleteAsync();
}