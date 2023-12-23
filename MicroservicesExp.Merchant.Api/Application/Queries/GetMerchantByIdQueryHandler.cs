using AutoMapper;
using MediatR;
using MicroservicesExp.Merchant.Domain.ViewModels;
using MicroservicesExp.Merchant.Infrastructure.Queries;

namespace MicroservicesExp.Merchant.Application.Queries;

public class GetMerchantByIdQueryHandler : IRequestHandler<GetMerchantByIdQuery, MerchantViewModel>
{
    private readonly IQuery _query;
    private readonly IMapper _mapper;

    public GetMerchantByIdQueryHandler(IQuery query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }
    public async Task<MerchantViewModel> Handle(GetMerchantByIdQuery request, CancellationToken cancellationToken)
    {
        var merchant = await _query.SingleOrDefaultAsync(l=> l.Id == request.Id, cancellationToken);
        return _mapper.Map<MerchantViewModel>(merchant);
    }
}