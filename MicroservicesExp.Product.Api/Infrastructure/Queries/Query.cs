using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace MicroservicesExp.Product.Api.Infrastructure.Queries;

public class Query<TEntity> : IQuery<TEntity> where TEntity : class
{
    private readonly DbContext _context;
    private readonly IQueryable<TEntity> entities;

    public Query(DbContext context)
    {
        _context = context;
        entities = _context.Set<TEntity>().AsNoTracking();
    }

    public async Task<TEntity> SingleOrDefaultAsync(CancellationToken cancellationToken = default)
    {
        return await entities.SingleOrDefaultAsync(cancellationToken);
    }
    public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await entities.SingleOrDefaultAsync(predicate, cancellationToken);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken)
    {
        return await entities.AnyAsync(predicate, cancellationToken);
    }

    public async Task<List<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
    {
        return await entities.Where(predicate).ToListAsync(cancellationToken);
    }

    public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await entities.ToListAsync(cancellationToken);
    }
}