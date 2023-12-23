using MediatR;
using MicroservicesExp.Merchant.Domain.ViewModels;

namespace MicroservicesExp.Merchant.Application.Queries;

public class GetMerchantByIdQuery: IRequest<MerchantViewModel>
{
    public Guid Id { get; protected set; }

    public GetMerchantByIdQuery(Guid id)
    {
        Id = id;
    }
}