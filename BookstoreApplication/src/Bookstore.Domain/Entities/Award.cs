namespace Bookstore.Domain.Entities;

public class Award
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public DateTime DateOfCreation { get; set; }

    public ICollection<AuthorAward> AuthorAwards { get; set; }
}