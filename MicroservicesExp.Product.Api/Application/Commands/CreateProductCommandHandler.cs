using AutoMapper;
using MediatR;
using MicroservicesExp.Product.Api.Infrastructure.Repositories;
using MicroservicesExp.Product.Api.Infrastructure.UnitOfWorks;

namespace MicroservicesExp.Product.Api.Application.Commands;

public class CreateProductCommandHandler: IRequestHandler<CreateProductCommand, bool>
{
    private readonly IProductUnitOfWork _unitOfWork;
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public CreateProductCommandHandler(IProductUnitOfWork unitOfWork, IProductRepository productRepository, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _productRepository = productRepository;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Domain.Aggregates.Product>(request);
        await _productRepository.MarkForInsertionAsync(product);
        _unitOfWork.Commit(true);
        
        return true;
    }
}