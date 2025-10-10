using AutoMapper;
using Bookstore.Application.Dtos.BookDtos.Requests;
using Bookstore.Application.Dtos.BookDtos.Responses;
using Bookstore.Application.Exceptions;
using Bookstore.Application.Interfaces;
using Bookstore.Application.Queries.BookQueries;
using Bookstore.Domain.Common;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;

namespace Bookstore.Application.Service;

public class BookService : IBookService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public BookService (IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<BookSummaryResponse>> GetAllAsync(BookQueryDto query)
    {
        var books = await _unitOfWork.Books.GetAllAsync(query.OrderBy);

        var bookSummaryDto = _mapper.Map<IEnumerable<BookSummaryResponse>>(books); 

        return bookSummaryDto;
    }

    public async Task<PaginatedList<BookSummaryResponse>> GetPagedAsync(BookQueryDto query)
    {
        var paginatedBooks = await _unitOfWork.Books.GetPagedAsync(
            query.CurrentPage, 
            query.PageSize, 
            query.OrderBy, 
            query.TitleFilter, 
            query.AuthorIdFilter, 
            query.AuthorFullNameFilter, 
            query.PublishedDateFromFilter, 
            query.PublishedDateToFilter, 
            query.AuthorDateOfBirthFromFilter, 
            query.AuthorDateOfBirthToFilter
            );

        var paginatedBooksDto = _mapper.Map<PaginatedList<BookSummaryResponse>>(paginatedBooks);

        return paginatedBooksDto;
    }

    public async Task<BookDetailResponse?> GetByIdAsync(int id)
    {
        var book = await _unitOfWork.Books.GetByIdAsync(id);

        if (book == null)
        {
            throw new NotFoundException($"Book with ID '{id}' was not found.");
        }

        var bookDto = _mapper.Map<BookDetailResponse>(book);

        return bookDto;
    }

    public async Task<BookDetailResponse> AddAsync(BookCreateRequest bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);

        _unitOfWork.Books.Add(book);

        await _unitOfWork.CompleteAsync();

        return _mapper.Map<BookDetailResponse>(book);
    }

    public async Task UpdateAsync(int id, BookUpdateRequest bookDto)
    {
        var book = await _unitOfWork.Books.GetByIdAsync(id);

        if (book == null)
        {
            throw new NotFoundException($"Book with ID '{id}' was not found.");
        }

        _mapper.Map(bookDto, book);

        _unitOfWork.Books.Update(book);

        await _unitOfWork.CompleteAsync();

        return;
    }

    public async Task DeleteAsync(int id)
    {
        var book = await _unitOfWork.Books.GetByIdAsync(id);

        if (book == null)
        {
            throw new NotFoundException($"Book with ID '{id}' was not found.");
        }

        _unitOfWork.Books.Delete(book);

        await _unitOfWork.CompleteAsync();

        return;
    }
}