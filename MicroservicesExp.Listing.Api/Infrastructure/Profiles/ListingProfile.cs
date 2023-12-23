using AutoMapper;
using MicroservicesExp.Listing.Api.Application.Commands;
using MicroservicesExp.Listing.Api.Domain.ViewModels;

namespace MicroservicesExp.Listing.Api.Infrastructure.Profiles;

public class ListingProfile: Profile
{
    public ListingProfile()
    {
        CreateMap<Listing.Api.Domain.Aggregates.Listing, ListingViewModel>()
            .ReverseMap();
        
        CreateMap<CreateListingCommand, Listing.Api.Domain.Aggregates.Listing>()
            .ConstructUsing(model => new Listing.Api.Domain.Aggregates.Listing(model.MerchantId, model.ProductId, model.Stock, model.Price));
    }
}