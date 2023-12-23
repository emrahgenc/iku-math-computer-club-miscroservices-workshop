namespace MicroservicesExp.Product.Api.Infrastructure.UnitOfWorks;

public interface IProductUnitOfWork
{
    int Commit(bool acceptAllChangesOnSuccess);
    void Rollback();
}