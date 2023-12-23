using AutoMapper;
using MediatR;
using MicroservicesExp.Listing.Api.Domain.ViewModels;
using MicroservicesExp.Listing.Infrastructure.Queries;

namespace MicroservicesExp.Listing.Api.Application.Queries;

public class GetListingByIdQueryHandler : IRequestHandler<GetListingByIdQuery, ListingViewModel>
{
    private readonly IQuery _query;
    private readonly IMapper _mapper;

    public GetListingByIdQueryHandler(IQuery query, IMapper mapper)
    {
        _query = query;
        _mapper = mapper;
    }
    public async Task<ListingViewModel> Handle(GetListingByIdQuery request, CancellationToken cancellationToken)
    {
        var listing = await _query.SingleOrDefaultAsync(l=> l.Id == request.Id, cancellationToken);
        return _mapper.Map<ListingViewModel>(listing);
    }
}