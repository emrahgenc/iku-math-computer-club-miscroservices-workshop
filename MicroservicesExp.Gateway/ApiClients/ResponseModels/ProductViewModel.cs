namespace MicroservicesExp.Gateway.ApiClients.ResponseModels;

public class ProductViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
}