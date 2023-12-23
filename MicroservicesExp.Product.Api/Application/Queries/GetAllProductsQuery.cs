using MediatR;
using MicroservicesExp.Product.Api.Domain.ViewModels;

namespace MicroservicesExp.Product.Api.Application.Queries;

public class GetAllProductsQuery: IRequest<List<ProductViewModel>>
{
}