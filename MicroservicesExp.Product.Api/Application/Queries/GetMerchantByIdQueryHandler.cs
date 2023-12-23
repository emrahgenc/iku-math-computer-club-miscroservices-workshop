using AutoMapper;
using MediatR;
using MicroservicesExp.Product.Api.Domain.ViewModels;
using MicroservicesExp.Product.Api.Infrastructure.Queries;

namespace MicroservicesExp.Product.Api.Application.Queries;

public class GetMerchantByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductViewModel>
{
    private readonly IQuery<Domain.Aggregates.Product> _query;
    private readonly IMapper _mapper;

    public GetMerchantByIdQueryHandler(IQuery<Domain.Aggregates.Product> query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }
    public async Task<ProductViewModel> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await _query.SingleOrDefaultAsync(l=> l.Id == request.Id, cancellationToken);
        return _mapper.Map<ProductViewModel>(product);
    }
}