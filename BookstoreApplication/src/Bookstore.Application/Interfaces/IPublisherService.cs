using Bookstore.Application.Dtos.PublisherDtos.Requests;
using Bookstore.Application.Dtos.PublisherDtos.Responses;
using Bookstore.Application.Queries.PublisherQueries;
using Bookstore.Domain.Common;


namespace Bookstore.Application.Interfaces;

public interface IPublisherService
{
    Task<IEnumerable<PublisherSummaryResponse>> GetAllAsync(PublisherQueryDto query);
    Task<PaginatedList<PublisherSummaryResponse>> GetPagedAsync(PublisherQueryDto query);
    Task<PublisherDetailResponse?> GetByIdAsync(int id);
    Task<PublisherDetailResponse> AddAsync(PublisherCreateRequest publisherDto);
    Task UpdateAsync(int id, PublisherUpdateRequest publisherDto);
    Task DeleteAsync(int id);
}
