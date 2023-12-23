using System.Linq.Expressions;
using MicroservicesExp.Listing.Api.Infrastructure.DbContexts;
using MicroservicesExp.Listing.Infrastructure.Queries;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace MicroservicesExp.Listing.Api.Infrastructure.Queries;

public class Query: IQuery
{
    private readonly ListingDbContext _context;
    private readonly IMongoQueryable<Listing.Api.Domain.Aggregates.Listing> entities;

    public Query(ListingDbContext context)
    {
        _context = context;
        entities = _context.Listings.AsQueryable();
    }

    public async Task<Listing.Api.Domain.Aggregates.Listing> SingleOrDefaultAsync(CancellationToken cancellationToken = default)
    {
        return await entities.SingleOrDefaultAsync(cancellationToken);
    }
    public async Task<Listing.Api.Domain.Aggregates.Listing> SingleOrDefaultAsync(Expression<Func<Listing.Api.Domain.Aggregates.Listing, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await entities.SingleOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<bool> AnyAsync(Expression<Func<Listing.Api.Domain.Aggregates.Listing, bool>> predicate, CancellationToken cancellationToken)
    {
        return await entities.AnyAsync(predicate, cancellationToken);
    }

    public async Task<List<Listing.Api.Domain.Aggregates.Listing>> GetAsync(Expression<Func<Listing.Api.Domain.Aggregates.Listing, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await entities.Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task<List<Listing.Api.Domain.Aggregates.Listing>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await entities.ToListAsync(cancellationToken);
    }
}