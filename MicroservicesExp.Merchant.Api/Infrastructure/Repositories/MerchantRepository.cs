using MicroservicesExp.Merchant.Infrastructure.DbContexts;
using MongoDB.Driver;

namespace MicroservicesExp.Merchant.Infrastructure.Repositories;

public class MerchantRepository : IMerchantRepository
{
    private readonly MerchantDbContext _dbContext;

    public MerchantRepository(MerchantDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Merchant.Domain.Aggregates.Merchant?> GetSingleAsync(Guid id)
    {
        return await _dbContext.Merchants.Find(merchant => merchant.Id == id).SingleOrDefaultAsync();
    }
    public async Task AddAsync(Merchant.Domain.Aggregates.Merchant merchant)
    {
        await _dbContext.Merchants.InsertOneAsync(merchant);
    }
    
    public async Task UpdateAsync(Merchant.Domain.Aggregates.Merchant merchant)
    {
        await _dbContext.Merchants.ReplaceOneAsync(Builders<Merchant.Domain.Aggregates.Merchant>.Filter.Eq("_id", merchant.Id), merchant);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _dbContext.Merchants.DeleteOneAsync(Builders<Merchant.Domain.Aggregates.Merchant>.Filter.Eq("_id", id));
    }
}