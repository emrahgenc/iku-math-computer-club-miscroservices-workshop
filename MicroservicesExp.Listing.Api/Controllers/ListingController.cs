using MediatR;
using MicroservicesExp.Listing.Api.Application.Commands;
using MicroservicesExp.Listing.Api.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesExp.Listing.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ListingController : Controller
{
    private readonly IMediator _mediator;

    public ListingController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("")]
    public async Task<IActionResult> Get()
    {
        var listings = await _mediator.Send(new GetAllListingsQuery());
        return Ok(listings);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        await Task.Delay(5000);
        var listings = await _mediator.Send(new GetListingByIdQuery(id));
        return Ok(listings);
    }
    
    [HttpPost("")]
    public async Task<IActionResult> Add(CreateListingCommand createProductCommand)
    {
        var result = await _mediator.Send(createProductCommand);
        return Ok(result);
    }
}