using AutoMapper;
using MediatR;
using MicroservicesExp.Listing.Api.Domain.ViewModels;
using MicroservicesExp.Listing.Infrastructure.Queries;

namespace MicroservicesExp.Listing.Api.Application.Queries;

public class GetAllListingsQueryHandler : IRequestHandler<GetAllListingsQuery, List<ListingViewModel>>
{
    private readonly IQuery _query;
    private readonly IMapper _mapper;

    public GetAllListingsQueryHandler(IQuery query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }
    public async Task<List<ListingViewModel>> Handle(GetAllListingsQuery request, CancellationToken cancellationToken)
    {
        var merchants = await _query.GetAllAsync(cancellationToken);
        return _mapper.Map<List<ListingViewModel>>(merchants);
    }
}