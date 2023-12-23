namespace MicroservicesExp.Merchant.Infrastructure.Repositories;

public interface IMerchantRepository
{
    Task<Merchant.Domain.Aggregates.Merchant?> GetSingleAsync(Guid id);
    Task AddAsync(Merchant.Domain.Aggregates.Merchant merchant);
    Task UpdateAsync(Merchant.Domain.Aggregates.Merchant merchant);
    Task DeleteAsync(Guid id);
}