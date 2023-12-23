using MediatR;
using MicroservicesExp.Product.Api.Application.Commands;
using MicroservicesExp.Product.Api.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesExp.Product.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : Controller
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("")]
    public async Task<IActionResult> Get()
    {
        var products = await _mediator.Send(new GetAllProductsQuery());
        return Ok(products);
    }
    
     
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var listings = await _mediator.Send(new GetProductByIdQuery(id));
        return Ok(listings);
    }

    
    [HttpPost("")]
    public async Task<IActionResult> Add(CreateProductCommand createProductCommand)
    {
        var result = await _mediator.Send(createProductCommand);
        return Ok(result);
    }
}