namespace Bookstore.Application.Dtos.PublisherDtos.Requests
{
    public class PublisherCreateRequest
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string Website { get; set; }
    }
}
