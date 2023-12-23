using MongoDB.Driver;

namespace MicroservicesExp.Listing.Api.Infrastructure.DbContexts;

public class ListingDbContext
{
    private readonly IMongoDatabase _database;

    public ListingDbContext(MongoClientSettings settings)
    {
        var mongoClient = new MongoClient(settings);
        _database = mongoClient.GetDatabase("Listings");
    }
    
    public IMongoCollection<Listing.Api.Domain.Aggregates.Listing> Listings
        => _database.GetCollection<Listing.Api.Domain.Aggregates.Listing>("Listings");
}

