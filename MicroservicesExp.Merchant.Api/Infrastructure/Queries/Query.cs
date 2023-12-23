using System.Linq.Expressions;
using MicroservicesExp.Merchant.Infrastructure.DbContexts;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MicroservicesExp.Merchant.Infrastructure.Queries;

public class Query: IQuery
{
    private readonly MerchantDbContext _context;
    private readonly IMongoQueryable<Merchant.Domain.Aggregates.Merchant> entities;

    public Query(MerchantDbContext context)
    {
        _context = context;
        entities = _context.Merchants.AsQueryable();
    }

    public async Task<Merchant.Domain.Aggregates.Merchant> SingleOrDefaultAsync(CancellationToken cancellationToken = default)
    {
        return await entities.SingleOrDefaultAsync(cancellationToken);
    }
    public async Task<Merchant.Domain.Aggregates.Merchant> SingleOrDefaultAsync(Expression<Func<Merchant.Domain.Aggregates.Merchant, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await entities.SingleOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<bool> AnyAsync(Expression<Func<Merchant.Domain.Aggregates.Merchant, bool>> predicate, CancellationToken cancellationToken)
    {
        return await entities.AnyAsync(predicate, cancellationToken);
    }

    public async Task<List<Merchant.Domain.Aggregates.Merchant>> GetAsync(Expression<Func<Merchant.Domain.Aggregates.Merchant, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await entities.Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task<List<Merchant.Domain.Aggregates.Merchant>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await entities.ToListAsync(cancellationToken);
    }
}