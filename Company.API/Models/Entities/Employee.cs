namespace Company.API.Models.Entities;

public class Employee : Entity
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public Guid Code { get; private set; }
    public Address Address { get; private set; }
    public List<Contract> Contracts { get; private set; }
    
    private Employee(string firstName, string lastName, Address address, Contract contract) : base()
    {
        Code = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Contracts = new List<Contract> {contract};
    }

    public static Employee Create(string firstName, string lastName, Address address, Contract contract)
    {
        var employee = new Employee(firstName, lastName, address, contract);
        contract.AssignEmployee(employee);

        return employee;
    }
}