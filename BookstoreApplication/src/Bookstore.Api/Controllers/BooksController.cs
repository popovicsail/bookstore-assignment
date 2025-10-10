using Microsoft.AspNetCore.Mvc;
using Bookstore.Application.Interfaces;
using Bookstore.Application.Queries.BookQueries;
using Bookstore.Domain.Common;
using Bookstore.Application.Dtos.BookDtos.Responses;
using Bookstore.Application.Dtos.BookDtos.Requests;

namespace Bookstore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookSummaryResponse>>> GetAllAsync([FromQuery] BookQueryDto query)
    {
        var books = await _bookService.GetAllAsync(query);

        return Ok(books);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedList<BookSummaryResponse>>> GetPagedAsync([FromQuery] BookQueryDto query)
    {
        var booksPaged = await _bookService.GetPagedAsync(query);

        return Ok(booksPaged);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDetailResponse>> GetByIdAsync(int id)
    {
        var book = await _bookService.GetByIdAsync(id);

        return Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult<BookDetailResponse>> CreateAsync(BookCreateRequest bookCreateRequest)
    {
        var book = await _bookService.AddAsync(bookCreateRequest);

        return CreatedAtAction(nameof(GetByIdAsync), new { id = book.Id }, book);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAsync(int id, BookUpdateRequest bookUpdateRequest)
    {
        await _bookService.UpdateAsync(id, bookUpdateRequest);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        await _bookService.DeleteAsync(id);

        return NoContent();
    }
}
