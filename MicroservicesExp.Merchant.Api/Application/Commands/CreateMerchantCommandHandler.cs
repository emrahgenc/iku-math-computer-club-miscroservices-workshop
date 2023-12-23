using AutoMapper;
using MediatR;
using MicroservicesExp.Merchant.Infrastructure.Repositories;

namespace MicroservicesExp.Merchant.Application.Commands;

public class CreateMerchantCommandHandler: IRequestHandler<CreateMerchantCommand, bool>
{
    private readonly IMerchantRepository _merchantRepository;
    private readonly IMapper _mapper;

    public CreateMerchantCommandHandler(IMerchantRepository merchantRepository, IMapper mapper)
    {
        _merchantRepository = merchantRepository;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateMerchantCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Domain.Aggregates.Merchant>(request);
        await _merchantRepository.AddAsync(product);
        
        return true;
    }
}