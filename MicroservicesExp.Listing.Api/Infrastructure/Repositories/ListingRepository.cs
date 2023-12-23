using MicroservicesExp.Listing.Api.Infrastructure.DbContexts;
using MongoDB.Driver;

namespace MicroservicesExp.Listing.Api.Infrastructure.Repositories;

public class ListingRepository : IListingRepository
{
    private readonly ListingDbContext _dbContext;

    public ListingRepository(ListingDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Listing.Api.Domain.Aggregates.Listing?> GetSingleAsync(Guid id)
    {
        return await _dbContext.Listings.Find(Listing => Listing.Id == id).SingleOrDefaultAsync();
    }
    public async Task AddAsync(Listing.Api.Domain.Aggregates.Listing Listing)
    {
        await _dbContext.Listings.InsertOneAsync(Listing);
    }
    public async Task UpdateAsync(Listing.Api.Domain.Aggregates.Listing listing)
    {
        await _dbContext.Listings.ReplaceOneAsync(Builders<Domain.Aggregates.Listing>.Filter.Eq("_id", listing.Id), listing);
    }
    public async Task DeleteAsync(Guid id)
    {
        await _dbContext.Listings.DeleteOneAsync(Builders<Listing.Api.Domain.Aggregates.Listing>.Filter.Eq("_id", id));
    }
}