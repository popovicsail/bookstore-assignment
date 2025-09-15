namespace BookstoreApplication.Dtos
{
    public class BookDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishedDate { get; set; }
        public string ISBN { get; set; }

        public AuthorDto Author { get; set; }
        public PublisherDto Publisher { get; set; }
    }
}