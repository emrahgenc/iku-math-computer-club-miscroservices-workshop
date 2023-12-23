using MassTransit;
using MediatR;
using MicroservicesExp.Merchant.Application.IntegrationEvents;
using MicroservicesExp.Merchant.Infrastructure.Repositories;

namespace MicroservicesExp.Merchant.Application.Commands;

public class CloseMerchantCommandHandler: IRequestHandler<CloseMerchantCommand, bool>
{
    private readonly IMerchantRepository _merchantRepository;
    private readonly IPublishEndpoint _publisher;

    public CloseMerchantCommandHandler(IMerchantRepository merchantRepository, IPublishEndpoint publisher)
    {
        _merchantRepository = merchantRepository;
        _publisher = publisher;
    }
    public async Task<bool> Handle(CloseMerchantCommand request, CancellationToken cancellationToken)
    {
        var merchant = await _merchantRepository.GetSingleAsync(request.MerchantId);
        merchant.Close();
        
        await _merchantRepository.UpdateAsync(merchant);
        
        await _publisher.Publish(new MerchantClosedIntegrationEvent(merchant.Id), cancellationToken);
        
        return true;
    }
}