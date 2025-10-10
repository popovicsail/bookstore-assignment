namespace Bookstore.Application.Queries.BookQueries;

public class BookQueryDto
{
    public int CurrentPage { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string OrderBy { get; set; } = "Title asc";

    public string? TitleFilter { get; set; }
    public DateTime? PublishedDateFromFilter { get; set; }
    public DateTime? PublishedDateToFilter { get; set; }
    public string? AuthorFullNameFilter { get; set; }
    public int? AuthorIdFilter { get; set; }
    public DateTime? AuthorDateOfBirthFromFilter { get; set; }
    public DateTime? AuthorDateOfBirthToFilter { get; set; }
}
