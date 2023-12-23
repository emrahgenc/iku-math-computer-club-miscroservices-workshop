namespace MicroservicesExp.Merchant.Domain.Aggregates;

public class Employee
{
    public string Name { get; protected set; }
    public string Email { get; protected set; }
    public string Phone { get; protected set; }

    public Employee(string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }
}