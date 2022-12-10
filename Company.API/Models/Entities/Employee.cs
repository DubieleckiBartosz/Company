namespace Company.API.Models.Entities;

public class Employee : Entity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Guid Code { get; private set; }
    public Address Address { get; private set; }
    public List<Contract> Contracts { get; private set; }

    public Employee(string firstName, string lastName, Address address, Contract contract)
    {
        Code = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Contracts = new List<Contract>();
        Contracts.Add(contract);
    }
}