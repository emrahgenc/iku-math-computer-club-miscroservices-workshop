namespace MicroservicesExp.Merchant.Application.IntegrationEvents;

public class MerchantClosedIntegrationEvent
{
    public Guid MerchantId { get; set; }

    public MerchantClosedIntegrationEvent(Guid merchantId)
    {
        MerchantId = merchantId;
    }
}