using AutoMapper;
using MediatR;
using MicroservicesExp.Listing.Api.Infrastructure.Repositories;

namespace MicroservicesExp.Listing.Api.Application.Commands;

public class CreateListingCommandHandler: IRequestHandler<CreateListingCommand, bool>
{
    private readonly IListingRepository _listingRepository;
    private readonly IMapper _mapper;

    public CreateListingCommandHandler(IListingRepository listingRepository, IMapper mapper)
    {
        _listingRepository = listingRepository;
        _mapper = mapper;
    }
    public async Task<bool> Handle(CreateListingCommand request, CancellationToken cancellationToken)
    {
        var product = _mapper.Map<Domain.Aggregates.Listing>(request);
        await _listingRepository.AddAsync(product);
        
        return true;
    }
}