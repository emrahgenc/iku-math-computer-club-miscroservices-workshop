using MicroservicesExp.Merchant.Domain.Aggregates;

namespace MicroservicesExp.Merchant.Domain.ViewModels;

public class MerchantViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<Employee> Employees { get; set; }
    public bool IsActive { get; set; }
}