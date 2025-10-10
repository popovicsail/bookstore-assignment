using Bookstore.Application.Dtos.BookDtos.Requests;
using Bookstore.Application.Dtos.BookDtos.Responses;
using Bookstore.Application.Queries.BookQueries;
using Bookstore.Domain.Common;

namespace Bookstore.Application.Interfaces;

public interface IBookService
{
    Task<IEnumerable<BookSummaryResponse>> GetAllAsync(BookQueryDto query);
    Task<PaginatedList<BookSummaryResponse>> GetPagedAsync(BookQueryDto query);
    Task<BookDetailResponse?> GetByIdAsync(int id);
    Task<BookDetailResponse> AddAsync(BookCreateRequest bookDto);
    Task UpdateAsync(int id, BookUpdateRequest bookDto);
    Task DeleteAsync(int id);
}
