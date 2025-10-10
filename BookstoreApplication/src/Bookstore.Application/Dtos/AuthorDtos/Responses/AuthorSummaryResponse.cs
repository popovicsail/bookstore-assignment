namespace Bookstore.Application.Dtos.AuthorDtos.Responses
{
    public class AuthorSummaryResponse
    {
        public required string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
