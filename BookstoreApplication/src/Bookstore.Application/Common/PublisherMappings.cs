using AutoMapper;
using Bookstore.Application.Dtos.PublisherDtos.Responses;
using Bookstore.Application.Dtos.PublisherDtos.Requests;
using Bookstore.Domain.Common;
using Bookstore.Domain.Entities;

namespace Bookstore.Application.Common;

public class PublisherMappings : Profile
{
    public PublisherMappings() 
    {
        CreateMap<Publisher, PublisherSummaryResponse>();

        CreateMap<Publisher, PublisherDetailResponse>();

        CreateMap<PaginatedList<Publisher>, PaginatedList<PublisherSummaryResponse>>();
    }
}
