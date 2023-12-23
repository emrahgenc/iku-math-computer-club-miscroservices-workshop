using MediatR;
using MicroservicesExp.Merchant.Application.Commands;
using MicroservicesExp.Merchant.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesExp.Merchant.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MerchantController : Controller
{
    private readonly IMediator _mediator;

    public MerchantController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("")]
    public async Task<IActionResult> Get()
    {
        var merchants = await _mediator.Send(new GetAllMerchantsQuery());
        return Ok(merchants);
    }
    
     
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var listings = await _mediator.Send(new GetMerchantByIdQuery(id));
        return Ok(listings);
    }

    
    [HttpPost("")]
    public async Task<IActionResult> Add(CreateMerchantCommand createProductCommand)
    {
        var result = await _mediator.Send(createProductCommand);
        return Ok(result);
    }
    
    [HttpPost("{id}/close")]
    public async Task<IActionResult> Close(Guid id)
    {
        var result = await _mediator.Send(new CloseMerchantCommand(id));
        return Ok(result);
    }
    
    [HttpPost("{id}/open")]
    public async Task<IActionResult> Open(Guid id)
    {
        var result = await _mediator.Send(new OpenMerchantCommand(id));
        return Ok(result);
    }
}