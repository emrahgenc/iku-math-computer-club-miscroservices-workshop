using MassTransit;
using MicroservicesExp.Listing.Api.Infrastructure.Repositories;
using MicroservicesExp.Listing.Infrastructure.Queries;
using MicroservicesExp.Merchant.Application.IntegrationEvents;

namespace MicroservicesExp.Listing.Api.Application.Consumers;

public class MerchantConsumer: IConsumer<MerchantClosedIntegrationEvent>
{
    private readonly IListingRepository _repository;
    private readonly IQuery _query;

    public MerchantConsumer(IListingRepository repository, IQuery query)
    {
        _repository = repository;
        _query = query;
    }
    public async Task Consume(ConsumeContext<MerchantClosedIntegrationEvent> context)
    {
        var listings = await _query.GetAsync(p => p.MerchantId == context.Message.MerchantId);
        foreach (var listing in listings)
        {
            listing.CloseForSale();
            await _repository.UpdateAsync(listing);
        }
    }
}