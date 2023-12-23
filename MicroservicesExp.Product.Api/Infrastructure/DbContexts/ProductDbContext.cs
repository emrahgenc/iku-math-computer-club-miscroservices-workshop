using Microsoft.EntityFrameworkCore;

namespace MicroservicesExp.Product.Api.Infrastructure.DbContexts;

public class ProductDbContext: DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
    {
    }
    
    public DbSet<Domain.Aggregates.Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var productModelBuilder = modelBuilder.Entity<Domain.Aggregates.Product>();
        
        productModelBuilder.ToTable("Products");
        productModelBuilder.HasKey(k=> k.Id);

        productModelBuilder.Property(p => p.Name).HasColumnType("varchar").HasMaxLength(100).IsRequired();
        productModelBuilder.Property(p => p.Category).HasColumnType("varchar").HasMaxLength(100).IsRequired();
        productModelBuilder.Property(p => p.Description).HasColumnType("varchar").HasMaxLength(500).IsRequired();
        productModelBuilder.Property(p => p.IsActive).IsRequired();

    }
}