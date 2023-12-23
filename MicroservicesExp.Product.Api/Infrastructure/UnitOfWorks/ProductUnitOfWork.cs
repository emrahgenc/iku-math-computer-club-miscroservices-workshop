using System.Data;
using MicroservicesExp.Product.Api.Infrastructure.DbContexts;

namespace MicroservicesExp.Product.Api.Infrastructure.UnitOfWorks;

public class ProductUnitOfWork : IProductUnitOfWork
{
    private readonly ProductDbContext _dbContext;

    public ProductUnitOfWork(ProductDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public int Commit(bool acceptAllChangesOnSuccess)
    {
        try
        {
            return _dbContext.SaveChanges(acceptAllChangesOnSuccess);
        }
        catch (Exception e)
        {
            Rollback();
            throw new DataException(e.Message, e);
        }
    }

    public void Rollback()
    {
        _dbContext.ChangeTracker.Clear();
    }
}