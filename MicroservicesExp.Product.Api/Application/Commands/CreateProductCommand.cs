using MediatR;

namespace MicroservicesExp.Product.Api.Application.Commands;

public class CreateProductCommand: IRequest<bool>
{
    public string Name { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
}