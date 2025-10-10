namespace Bookstore.Application.Queries.AuthorQueries
{
    public class AuthorQueryDto
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string OrderBy { get; set; } = "FullName asc";
    }
}
