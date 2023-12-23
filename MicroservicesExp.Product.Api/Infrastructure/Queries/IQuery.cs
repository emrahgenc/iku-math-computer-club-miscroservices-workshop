using System.Linq.Expressions;

namespace MicroservicesExp.Product.Api.Infrastructure.Queries;

public interface IQuery<TEntity>
{
    Task<TEntity> SingleOrDefaultAsync(CancellationToken cancellationToken = default);
    Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default);
    Task<List<TEntity>> GetAllAsync(
        CancellationToken cancellationToken = default);
}