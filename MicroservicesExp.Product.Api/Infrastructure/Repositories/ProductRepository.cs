using MicroservicesExp.Product.Api.Infrastructure.DbContexts;

namespace MicroservicesExp.Product.Api.Infrastructure.Repositories;

public interface IProductRepository
{
    Task<Domain.Aggregates.Product?> GetSingleAsync(object? id);
    Task MarkForInsertionAsync(Domain.Aggregates.Product product);
    Task MarkForDeletionAsync(Guid id);
}

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _dbContext;

    public ProductRepository(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Domain.Aggregates.Product?> GetSingleAsync(object? id)
    {
        return await _dbContext.Products.FindAsync(id);
    }
    public async Task MarkForInsertionAsync(Domain.Aggregates.Product product)
    {
        await _dbContext.Products.AddAsync(product);
    }
    
    public async Task MarkForDeletionAsync(Guid id)
    {
        var product = await GetSingleAsync(id);
        if (product != null) 
            _dbContext.Products.Remove(product);
    }
}