using MicroservicesExp.Gateway.ApiClients.ResponseModels;
using Refit;

namespace MicroservicesExp.Gateway.ApiClients;

public interface IListingApiClient
{
    [Get("/api/listing/{id}")]
    Task<ListingViewModel> GetAsync(Guid id);
}