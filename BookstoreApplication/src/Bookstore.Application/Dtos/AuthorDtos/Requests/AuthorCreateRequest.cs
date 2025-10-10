namespace Bookstore.Application.Dtos.AuthorDtos.Requests
{
    public class AuthorCreateRequest
    {
        public required string FullName { get; set; }
        public required string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
