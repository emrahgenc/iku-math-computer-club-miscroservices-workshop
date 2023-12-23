namespace MicroservicesExp.Listing.Api.Domain.ViewModels;

public class ListingViewModel
{
    public Guid Id { get; set; }
    public Guid MerchantId { get; set; }
    public Guid ProductId { get; set; }
    public int Stock { get; set; }
    public double Price { get; set; }
    public bool IsActive { get; set; }
}