using Bookstore.Application.Dtos.AuthorDtos.Requests;
using Bookstore.Application.Dtos.AuthorDtos.Responses;
using Bookstore.Application.Queries.AuthorQueries;
using Bookstore.Domain.Common;


namespace Bookstore.Application.Interfaces;

public interface IAuthorService
{
    Task<IEnumerable<AuthorSummaryResponse>> GetAllAsync(AuthorQueryDto query);
    Task<PaginatedList<AuthorSummaryResponse>> GetPagedAsync(AuthorQueryDto query);
    Task<AuthorDetailResponse?> GetByIdAsync(int id);
    Task<AuthorDetailResponse> AddAsync(AuthorCreateRequest authorDto);
    Task UpdateAsync(int id, AuthorUpdateRequest authorDto);
    Task DeleteAsync(int id);
}
