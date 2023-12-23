using System.Linq.Expressions;

namespace MicroservicesExp.Listing.Infrastructure.Queries;

public interface IQuery
{
    Task<Listing.Api.Domain.Aggregates.Listing> SingleOrDefaultAsync(CancellationToken cancellationToken = default);
    Task<Listing.Api.Domain.Aggregates.Listing> SingleOrDefaultAsync(Expression<Func<Listing.Api.Domain.Aggregates.Listing, bool>> predicate, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<Listing.Api.Domain.Aggregates.Listing, bool>> predicate, CancellationToken cancellationToken = default);
    Task<List<Listing.Api.Domain.Aggregates.Listing>> GetAsync(Expression<Func<Listing.Api.Domain.Aggregates.Listing, bool>> predicate,
        CancellationToken cancellationToken = default);
    Task<List<Listing.Api.Domain.Aggregates.Listing>> GetAllAsync(
        CancellationToken cancellationToken = default);
}