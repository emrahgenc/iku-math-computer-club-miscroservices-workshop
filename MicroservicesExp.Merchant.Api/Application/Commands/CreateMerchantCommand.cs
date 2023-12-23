using MediatR;

namespace MicroservicesExp.Merchant.Application.Commands;

public class CreateMerchantCommand : IRequest<bool>
{
    public string Name { get; set; }
    public string Address { get; set; }
}