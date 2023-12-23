namespace MicroservicesExp.Listing.Api.Infrastructure.Repositories;

public interface IListingRepository
{
    Task<Listing.Api.Domain.Aggregates.Listing?> GetSingleAsync(Guid id);
    Task AddAsync(Listing.Api.Domain.Aggregates.Listing Listing);
    Task UpdateAsync(Listing.Api.Domain.Aggregates.Listing listing);
    Task DeleteAsync(Guid id);
}