using FluentValidation;

namespace Bookstore.Application.Queries.BookQueries;

public class BookQueryDtoValidator : AbstractValidator<BookQueryDto>
{
    readonly List<string> _allowedSortByValues = new List<string>
    {   
        "title",
        "title_desc",
        "author",
        "author_desc"
    };

    public BookQueryDtoValidator()
    {
        RuleFor(dto => dto.OrderBy)
            .Must(value => _allowedSortByValues.Contains(value.ToLower()))
            .WithMessage("Greška u sortiranju.");
    }
}