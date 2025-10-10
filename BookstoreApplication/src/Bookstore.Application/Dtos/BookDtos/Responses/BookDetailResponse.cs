namespace Bookstore.Application.Dtos.BookDtos.Responses;

public class BookDetailResponse
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public int PageCount { get; set; }
    public DateTime PublishedDate { get; set; }
    public required string ISBN { get; set; }

    public int BookAge { get; set; }
    public int AuthorId { get; set; }
    public string? AuthorName { get; set; }
    public int PublisherId { get; set; }
    public string? PublisherName { get; set; }
}
