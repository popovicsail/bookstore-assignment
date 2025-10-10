namespace Bookstore.Application.Dtos.PublisherDtos.Requests
{
    public class PublisherUpdateRequest
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required string Website { get; set; }
    }
}
