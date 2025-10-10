using Microsoft.AspNetCore.Mvc;
using Bookstore.Application.Interfaces;
using Bookstore.Application.Queries.AuthorQueries;
using Bookstore.Domain.Common;
using Bookstore.Application.Dtos.AuthorDtos.Responses;
using Bookstore.Application.Dtos.AuthorDtos.Requests;

namespace Bookstore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthorsController : ControllerBase
{
    private readonly IAuthorService _authorService;

    public AuthorsController(IAuthorService authorService)
    {
        _authorService = authorService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorSummaryResponse>>> GetAllAsync([FromQuery] AuthorQueryDto query)
    {
        var authors = await _authorService.GetAllAsync(query);

        return Ok(authors);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedList<AuthorSummaryResponse>>> GetPagedAsync([FromQuery] AuthorQueryDto query)
    {
        var authorsPaged = await _authorService.GetPagedAsync(query);

        return Ok(authorsPaged);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorDetailResponse>> GetByIdAsync(int id)
    {
        var author = await _authorService.GetByIdAsync(id);

        return Ok(author);
    }

    [HttpPost]
    public async Task<ActionResult<AuthorDetailResponse>> CreateAsync(AuthorCreateRequest authorCreateRequest)
    {
        var author = await _authorService.AddAsync(authorCreateRequest);

        return CreatedAtAction(nameof(GetByIdAsync), new { id = author.Id }, author);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAsync(int id, AuthorUpdateRequest authorUpdateRequest)
    {
        await _authorService.UpdateAsync(id, authorUpdateRequest);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        await _authorService.DeleteAsync(id);

        return NoContent();
    }
}
