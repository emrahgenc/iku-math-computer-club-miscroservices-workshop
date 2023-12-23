using MediatR;

namespace MicroservicesExp.Merchant.Application.Commands;

public class OpenMerchantCommand: IRequest<bool>
{
    public Guid MerchantId { get; set; }

    public OpenMerchantCommand(Guid merchantId)
    {
        MerchantId = merchantId;
    }
}