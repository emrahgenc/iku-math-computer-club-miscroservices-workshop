using MongoDB.Bson.Serialization.Attributes;

namespace MicroservicesExp.Listing.Api.Domain.Aggregates;

public class Listing
{
    [BsonId]
    public Guid Id { get; protected set; }
    public Guid MerchantId { get; protected set; }
    public Guid ProductId { get; protected set; }
    public int Stock { get; protected set; }
    public double Price { get; protected set; }
    public bool IsActive { get; protected set; }

    public Listing(Guid merchantId, Guid productId, int stock, double price)
    {
        MerchantId = merchantId;
        ProductId = productId;
        Stock = stock;
        Price = price;
        Id = Guid.NewGuid();
        IsActive = stock > 0 && price > 0.0;
    }

    public void DecreaseStock()
    {
        if (Stock <= 0)
        {
            throw new ApplicationException("You cannot reduce stock on depleted stock.");
        }

        Stock -= 1;
    }

    public void CloseForSale()
    {
        IsActive = false;
    }
}
