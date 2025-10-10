using AutoMapper;
using Bookstore.Application.Exceptions;
using Bookstore.Domain.Common;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using Bookstore.Application.Dtos.AuthorDtos.Requests;
using Bookstore.Application.Dtos.AuthorDtos.Responses;
using Bookstore.Application.Queries.AuthorQueries;
using Bookstore.Application.Interfaces;

namespace Bookstore.Application.Service;

public class AuthorService : IAuthorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public AuthorService (IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AuthorSummaryResponse>> GetAllAsync(AuthorQueryDto query)
    {
        var authors = await _unitOfWork.Authors.GetAllAsync(query.OrderBy);

        var authorSummaryDto = _mapper.Map<IEnumerable<AuthorSummaryResponse>>(authors); 

        return authorSummaryDto;
    }

    public async Task<PaginatedList<AuthorSummaryResponse>> GetPagedAsync(AuthorQueryDto query)
    {
        var paginatedAuthors = await _unitOfWork.Authors.GetPagedAsync(query.CurrentPage, query.PageSize, query.OrderBy);

        var paginatedAuthorsDto = _mapper.Map<PaginatedList<AuthorSummaryResponse>>(paginatedAuthors);

        return paginatedAuthorsDto;
    }

    public async Task<AuthorDetailResponse?> GetByIdAsync(int id)
    {
        var author = await _unitOfWork.Authors.GetByIdAsync(id);

        if (author == null)
        {
            throw new NotFoundException($"Author with ID '{id}' was not found.");
        }

        var authorDto = _mapper.Map<AuthorDetailResponse>(author);

        return authorDto;
    }

    public async Task<AuthorDetailResponse> AddAsync(AuthorCreateRequest authorDto)
    {
        var author = _mapper.Map<Author>(authorDto);

        _unitOfWork.Authors.Add(author);

        await _unitOfWork.CompleteAsync();

        return _mapper.Map<AuthorDetailResponse>(author);
    }

    public async Task UpdateAsync(int id, AuthorUpdateRequest authorDto)
    {
        var author = await _unitOfWork.Authors.GetByIdAsync(id);

        if (author == null)
        {
            throw new NotFoundException($"Author with ID '{id}' was not found.");
        }

        _mapper.Map(authorDto, author);

        _unitOfWork.Authors.Update(author);

        await _unitOfWork.CompleteAsync();

        return;
    }

    public async Task DeleteAsync(int id)
    {
        var author = await _unitOfWork.Authors.GetByIdAsync(id);

        if (author == null)
        {
            throw new NotFoundException($"Author with ID '{id}' was not found.");
        }

        _unitOfWork.Authors.Delete(author);

        await _unitOfWork.CompleteAsync();

        return;
    }
}