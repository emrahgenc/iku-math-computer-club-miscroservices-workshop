using MediatR;

namespace MicroservicesExp.Merchant.Application.Commands;

public class CloseMerchantCommand: IRequest<bool>
{
    public Guid MerchantId { get; set; }

    public CloseMerchantCommand(Guid merchantId)
    {
        MerchantId = merchantId;
    }
}