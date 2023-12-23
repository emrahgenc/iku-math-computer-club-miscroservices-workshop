using MediatR;

namespace MicroservicesExp.Listing.Api.Application.Commands;

public class CreateListingCommand: IRequest<bool>
{
    public Guid MerchantId { get; set; }
    public Guid ProductId { get; set; }
    public int Stock { get; set; }
    public double Price { get; set; }
}