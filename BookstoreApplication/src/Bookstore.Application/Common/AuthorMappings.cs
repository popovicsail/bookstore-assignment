using AutoMapper;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Common;
using Bookstore.Application.Dtos.AuthorDtos.Responses;
using Bookstore.Application.Dtos.AuthorDtos.Requests;

namespace Bookstore.Application.Common;

public class AuthorMappings : Profile
{
    public AuthorMappings() 
    {
        CreateMap<Author, AuthorSummaryResponse>();

        CreateMap<Author, AuthorDetailResponse>();

        CreateMap<PaginatedList<Author>, PaginatedList<AuthorSummaryResponse>>();
    }
}
