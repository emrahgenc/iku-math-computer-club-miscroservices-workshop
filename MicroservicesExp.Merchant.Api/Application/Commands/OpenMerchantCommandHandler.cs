using MassTransit;
using MediatR;
using MicroservicesExp.Merchant.Infrastructure.Repositories;

namespace MicroservicesExp.Merchant.Application.Commands;

public class OpenMerchantCommandHandler: IRequestHandler<OpenMerchantCommand, bool>
{
    private readonly IMerchantRepository _merchantRepository;
    private readonly IPublishEndpoint _publisher;

    public OpenMerchantCommandHandler(IMerchantRepository merchantRepository, IPublishEndpoint publisher)
    {
        _merchantRepository = merchantRepository;
        _publisher = publisher;
    }
    public async Task<bool> Handle(OpenMerchantCommand request, CancellationToken cancellationToken)
    {
        var merchant = await _merchantRepository.GetSingleAsync(request.MerchantId);
        merchant.Open();
        
        await _merchantRepository.UpdateAsync(merchant);
        
        return true;
    }
}