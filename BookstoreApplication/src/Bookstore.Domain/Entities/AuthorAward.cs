namespace Bookstore.Domain.Entities;

public class AuthorAward
{
    public int Id { get; set; }

    public int AuthorId { get; set; }
    public Author Author { get; set; }
    
    public int AwardId { get; set; }
    public Award Award { get; set; }

    public DateTime DateOfWinning { get; set; }
}
