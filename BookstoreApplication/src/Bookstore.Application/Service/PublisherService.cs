using AutoMapper;
using Bookstore.Application.Exceptions;
using Bookstore.Domain.Common;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Interfaces;
using Bookstore.Application.Dtos.PublisherDtos.Requests;
using Bookstore.Application.Dtos.PublisherDtos.Responses;
using Bookstore.Application.Queries.PublisherQueries;
using Bookstore.Application.Interfaces;

namespace Bookstore.Application.Service;

public class PublisherService : IPublisherService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    
    public PublisherService (IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PublisherSummaryResponse>> GetAllAsync(PublisherQueryDto query)
    {
        var publishers = await _unitOfWork.Publishers.GetAllAsync(query.OrderBy);

        var publisherSummaryDto = _mapper.Map<IEnumerable<PublisherSummaryResponse>>(publishers); 

        return publisherSummaryDto;
    }

    public async Task<PaginatedList<PublisherSummaryResponse>> GetPagedAsync(PublisherQueryDto query)
    {
        var paginatedPublishers = await _unitOfWork.Publishers.GetPagedAsync(query.CurrentPage, query.PageSize, query.OrderBy);

        var paginatedPublishersDto = _mapper.Map<PaginatedList<PublisherSummaryResponse>>(paginatedPublishers);

        return paginatedPublishersDto;
    }

    public async Task<PublisherDetailResponse?> GetByIdAsync(int id)
    {
        var publisher = await _unitOfWork.Publishers.GetByIdAsync(id);

        if (publisher == null)
        {
            throw new NotFoundException($"Publisher with ID '{id}' was not found.");
        }

        var publisherDto = _mapper.Map<PublisherDetailResponse>(publisher);

        return publisherDto;
    }

    public async Task<PublisherDetailResponse> AddAsync(PublisherCreateRequest publisherDto)
    {
        var publisher = _mapper.Map<Publisher>(publisherDto);

        _unitOfWork.Publishers.Add(publisher);

        await _unitOfWork.CompleteAsync();

        return _mapper.Map<PublisherDetailResponse>(publisher);
    }

    public async Task UpdateAsync(int id, PublisherUpdateRequest publisherDto)
    {
        var publisher = await _unitOfWork.Publishers.GetByIdAsync(id);

        if (publisher == null)
        {
            throw new NotFoundException($"Publisher with ID '{id}' was not found.");
        }

        _mapper.Map(publisherDto, publisher);

        _unitOfWork.Publishers.Update(publisher);

        await _unitOfWork.CompleteAsync();

        return;
    }

    public async Task DeleteAsync(int id)
    {
        var publisher = await _unitOfWork.Publishers.GetByIdAsync(id);

        if (publisher == null)
        {
            throw new NotFoundException($"Publisher with ID '{id}' was not found.");
        }

        _unitOfWork.Publishers.Delete(publisher);

        await _unitOfWork.CompleteAsync();

        return;
    }
}