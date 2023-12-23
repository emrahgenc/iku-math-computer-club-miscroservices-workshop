using MicroservicesExp.Gateway.ApiClients.ResponseModels;
using Refit;

namespace MicroservicesExp.Gateway.ApiClients;

public interface IProductApiClient
{
    [Get("/api/product/{id}")]
    Task<ProductViewModel> GetAsync(Guid id);
}