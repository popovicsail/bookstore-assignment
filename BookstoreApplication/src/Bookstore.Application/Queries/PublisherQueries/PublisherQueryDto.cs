namespace Bookstore.Application.Queries.PublisherQueries
{
    public class PublisherQueryDto
    {
        public int CurrentPage { get; set; } = 1;
        public int PageSize { get; set; } = 10;
        public string OrderBy { get; set; } = "Name asc";
    }
}
