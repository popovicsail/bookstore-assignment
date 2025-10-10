using AutoMapper;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Common;
using Bookstore.Application.Dtos.BookDtos.Responses;

namespace Bookstore.Application.Common;

public class BookMappings : Profile
{
    public BookMappings() 
    {
        CreateMap<Book, BookSummaryResponse>()
            .ForMember(
            dest => dest.AuthorName,
            opt => opt.MapFrom(src => src.Author.FullName))
            .ForMember(
            dest => dest.PublisherName,
            opt => opt.MapFrom(src => src.Publisher.Name));

        CreateMap<Book, BookDetailResponse>()
            .ForMember(
            dest => dest.BookAge,
            opt => opt.MapFrom(src => $"{DateTime.Now.Year - src.PublishedDate.Year}"))
            .ForMember(
            dest => dest.AuthorName,
            opt => opt.MapFrom(src => src.Author.FullName))
            .ForMember(
            dest => dest.PublisherName,
            opt => opt.MapFrom(src => src.Publisher.Name))
            .ForMember(
            dest => dest.PublisherId,
            opt => opt.MapFrom(src => src.Publisher.Id))
            .ForMember(
            dest => dest.AuthorId,
            opt => opt.MapFrom(src => src.Author.Id));

        CreateMap<PaginatedList<Book>, PaginatedList<BookSummaryResponse>>();
    }
}
