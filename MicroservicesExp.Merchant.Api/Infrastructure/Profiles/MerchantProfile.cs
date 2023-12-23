using AutoMapper;
using MicroservicesExp.Merchant.Application.Commands;
using MicroservicesExp.Merchant.Domain.ViewModels;

namespace MicroservicesExp.Merchant.Infrastructure.Profiles;

public class MerchantProfile: Profile
{
    public MerchantProfile()
    {
        CreateMap<Merchant.Domain.Aggregates.Merchant, MerchantViewModel>()
            .ReverseMap();
        
        CreateMap<CreateMerchantCommand, Merchant.Domain.Aggregates.Merchant>()
            .ConstructUsing(model => new Merchant.Domain.Aggregates.Merchant(model.Name, model.Address));
    }
}