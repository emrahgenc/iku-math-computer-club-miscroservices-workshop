using MediatR;
using MicroservicesExp.Listing.Api.Domain.ViewModels;

namespace MicroservicesExp.Listing.Api.Application.Queries;

public class GetListingByIdQuery: IRequest<ListingViewModel>
{
    public Guid Id { get; protected set; }

    public GetListingByIdQuery(Guid id)
    {
        Id = id;
    }
}