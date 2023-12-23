using MicroservicesExp.Gateway.ApiClients;
using Microsoft.AspNetCore.Mvc;

namespace MicroservicesExp.Gateway.Controllers;

[Route("api/[controller]")]
public class ListingController : Controller
{
    private readonly IMerchantApiClient _merchantApiClient;
    private readonly IProductApiClient _productApiClient;
    private readonly IListingApiClient _listingApiClient;

    public ListingController(IMerchantApiClient merchantApiClient, IProductApiClient productApiClient, IListingApiClient listingApiClient)
    {
        _merchantApiClient = merchantApiClient;
        _productApiClient = productApiClient;
        _listingApiClient = listingApiClient;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var listing = await _listingApiClient.GetAsync(id);
        listing.Merchant = await _merchantApiClient.GetAsync(listing.MerchantId);
        listing.Product = await _productApiClient.GetAsync(listing.ProductId);
        
        return Ok(listing);
    }
}