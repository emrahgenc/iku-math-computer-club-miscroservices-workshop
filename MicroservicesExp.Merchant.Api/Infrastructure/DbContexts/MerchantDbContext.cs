using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace MicroservicesExp.Merchant.Infrastructure.DbContexts;

public class MerchantDbContext
{
    private readonly IMongoDatabase _database;

    public MerchantDbContext(MongoClientSettings settings)
    {
        var mongoClient = new MongoClient(settings);
        _database = mongoClient.GetDatabase("Merchants");
    }
    
    public IMongoCollection<Merchant.Domain.Aggregates.Merchant> Merchants 
        => _database.GetCollection<Merchant.Domain.Aggregates.Merchant>("Merchants");
}

