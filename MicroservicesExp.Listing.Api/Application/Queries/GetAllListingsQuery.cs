using MediatR;
using MicroservicesExp.Listing.Api.Domain.ViewModels;

namespace MicroservicesExp.Listing.Api.Application.Queries;

public class GetAllListingsQuery: IRequest<List<ListingViewModel>>
{
}