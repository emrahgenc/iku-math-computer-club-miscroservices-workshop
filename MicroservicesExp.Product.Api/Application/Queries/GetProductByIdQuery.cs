using MediatR;
using MicroservicesExp.Product.Api.Domain.ViewModels;

namespace MicroservicesExp.Product.Api.Application.Queries;

public class GetProductByIdQuery: IRequest<ProductViewModel>
{
    public Guid Id { get; protected set; }

    public GetProductByIdQuery(Guid id)
    {
        Id = id;
    }
}