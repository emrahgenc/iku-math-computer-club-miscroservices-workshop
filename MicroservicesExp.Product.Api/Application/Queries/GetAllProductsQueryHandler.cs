using AutoMapper;
using MediatR;
using MicroservicesExp.Product.Api.Domain.ViewModels;
using MicroservicesExp.Product.Api.Infrastructure.Queries;

namespace MicroservicesExp.Product.Api.Application.Queries;

public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, List<ProductViewModel>>
{
    private readonly IQuery<Domain.Aggregates.Product> _productQuery;
    private readonly IMapper _mapper;

    public GetAllProductsQueryHandler(IQuery<Domain.Aggregates.Product> productQuery, IMapper mapper)
    {
        _productQuery = productQuery;
        _mapper = mapper;
    }
    public async Task<List<ProductViewModel>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
    {
        var products = await _productQuery.GetAllAsync(cancellationToken);
        return _mapper.Map<List<ProductViewModel>>(products);
    }
}