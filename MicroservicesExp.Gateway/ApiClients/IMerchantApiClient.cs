using MicroservicesExp.Gateway.ApiClients.ResponseModels;
using Refit;

namespace MicroservicesExp.Gateway.ApiClients;

public interface IMerchantApiClient
{
    [Get("/api/merchant/{id}")]
    Task<MerchantViewModel> GetAsync(Guid id);
}