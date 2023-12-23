using MediatR;
using MicroservicesExp.Merchant.Domain.ViewModels;

namespace MicroservicesExp.Merchant.Application.Queries;

public class GetAllMerchantsQuery: IRequest<List<MerchantViewModel>>
{
}