using System.Linq.Expressions;

namespace MicroservicesExp.Merchant.Infrastructure.Queries;

public interface IQuery
{
    Task<Merchant.Domain.Aggregates.Merchant> SingleOrDefaultAsync(CancellationToken cancellationToken = default);
    Task<Merchant.Domain.Aggregates.Merchant> SingleOrDefaultAsync(Expression<Func<Merchant.Domain.Aggregates.Merchant, bool>> predicate, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<Merchant.Domain.Aggregates.Merchant, bool>> predicate, CancellationToken cancellationToken = default);
    Task<List<Merchant.Domain.Aggregates.Merchant>> GetAsync(Expression<Func<Merchant.Domain.Aggregates.Merchant, bool>> predicate,
        CancellationToken cancellationToken = default);
    Task<List<Merchant.Domain.Aggregates.Merchant>> GetAllAsync(
        CancellationToken cancellationToken = default);
}