namespace Bookstore.Application.Dtos.PublisherDtos.Responses
{
    public class PublisherDetailResponse
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string Website { get; set; }
    }
}
