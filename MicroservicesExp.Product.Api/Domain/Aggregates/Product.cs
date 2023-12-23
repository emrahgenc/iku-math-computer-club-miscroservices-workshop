namespace MicroservicesExp.Product.Api.Domain.Aggregates;

public class Product
{
    public Guid Id { get; protected set; }
    public string Name { get; protected set; }
    public string Category { get; protected set; }
    public string Description { get; protected set; }
    public bool IsActive { get; protected set; }

    public Product(string name, string category, string description)
    {
        Name = name;
        Category = category;
        Description = description;
        Id = Guid.NewGuid();
        IsActive = true;
    }
}