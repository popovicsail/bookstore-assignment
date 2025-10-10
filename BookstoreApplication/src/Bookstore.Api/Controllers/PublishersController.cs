using Microsoft.AspNetCore.Mvc;
using Bookstore.Application.Interfaces;
using Bookstore.Application.Queries.PublisherQueries;
using Bookstore.Domain.Common;
using Bookstore.Application.Dtos.PublisherDtos.Responses;
using Bookstore.Application.Dtos.PublisherDtos.Requests;

namespace Bookstore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublishersController : ControllerBase
{
    private readonly IPublisherService _publisherService;

    public PublishersController(IPublisherService publisherService)
    {
        _publisherService = publisherService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PublisherSummaryResponse>>> GetAllAsync([FromQuery] PublisherQueryDto query)
    {
        var publishers = await _publisherService.GetAllAsync(query);

        return Ok(publishers);
    }

    [HttpGet("paged")]
    public async Task<ActionResult<PaginatedList<PublisherSummaryResponse>>> GetPagedAsync([FromQuery] PublisherQueryDto query)
    {
        var publishersPaged = await _publisherService.GetPagedAsync(query);

        return Ok(publishersPaged);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PublisherDetailResponse>> GetByIdAsync(int id)
    {
        var publisher = await _publisherService.GetByIdAsync(id);

        return Ok(publisher);
    }

    [HttpPost]
    public async Task<ActionResult<PublisherDetailResponse>> CreateAsync(PublisherCreateRequest publisherCreateRequest)
    {
        var publisher = await _publisherService.AddAsync(publisherCreateRequest);

        return CreatedAtAction(nameof(GetByIdAsync), new { id = publisher.Id }, publisher);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAsync(int id, PublisherUpdateRequest publisherUpdateRequest)
    {
        await _publisherService.UpdateAsync(id, publisherUpdateRequest);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        await _publisherService.DeleteAsync(id);

        return NoContent();
    }
}
