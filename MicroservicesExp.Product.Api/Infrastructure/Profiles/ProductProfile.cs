using AutoMapper;
using MicroservicesExp.Product.Api.Application.Commands;
using MicroservicesExp.Product.Api.Domain.ViewModels;

namespace MicroservicesExp.Product.Api.Infrastructure.Profiles;

public class ProductProfile: Profile
{
    public ProductProfile()
    {
        CreateMap<Domain.Aggregates.Product, ProductViewModel>()
            .ReverseMap();
        
        CreateMap<CreateProductCommand, Domain.Aggregates.Product>()
            .ConstructUsing(model => new Domain.Aggregates.Product(model.Name, model.Category,model.Description));
    }
}