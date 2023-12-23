using AutoMapper;
using MediatR;
using MicroservicesExp.Merchant.Domain.ViewModels;
using MicroservicesExp.Merchant.Infrastructure.Queries;

namespace MicroservicesExp.Merchant.Application.Queries;

public class GetAllMerchantsQueryHandler : IRequestHandler<GetAllMerchantsQuery, List<MerchantViewModel>>
{
    private readonly IQuery _query;
    private readonly IMapper _mapper;

    public GetAllMerchantsQueryHandler(IQuery query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }
    public async Task<List<MerchantViewModel>> Handle(GetAllMerchantsQuery request, CancellationToken cancellationToken)
    {
        var merchants = await _query.GetAllAsync(cancellationToken);
        return _mapper.Map<List<MerchantViewModel>>(merchants);
    }
}