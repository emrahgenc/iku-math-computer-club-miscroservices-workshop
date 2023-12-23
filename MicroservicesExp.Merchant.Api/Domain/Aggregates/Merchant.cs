using MongoDB.Bson.Serialization.Attributes;

namespace MicroservicesExp.Merchant.Domain.Aggregates;

public class Merchant
{
    [BsonId]
    public Guid Id { get; protected set; }
    public string Name { get; protected set; }
    public string Address { get; protected set; }
    public List<Employee> Employees { get; protected set; }
    public bool IsActive { get; protected set; }

    public Merchant(string name, string address)
    {
        Name = name;
        Address = address;
        Id = Guid.NewGuid();
        IsActive = true;

        Employees = new List<Employee>();
    }

    public void AddEmployee(string name, string email, string phone)
    {
        Employees.Add(new Employee(name, email, phone));
    }
    
    public void Close()
    {
        IsActive = false;
    }
    
    public void Open()
    {
        IsActive = true;
    }
}