namespace MicroservicesExp.Gateway.ApiClients.ResponseModels;

public class MerchantViewModel
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public List<EmployeeViewModel> Employees { get; set; }
    public bool IsActive { get; set; }
}