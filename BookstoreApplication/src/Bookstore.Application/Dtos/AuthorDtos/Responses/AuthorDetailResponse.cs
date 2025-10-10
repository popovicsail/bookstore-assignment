namespace Bookstore.Application.Dtos.AuthorDtos.Responses
{
    public class AuthorDetailResponse
    {
        public int Id { get; set; }
        public required string FullName { get; set; }
        public required string Biography { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
