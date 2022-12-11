namespace Company.API.Models.Documents;

public class Employee : Base
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Code { get; private set; }
    public Address EmployeeAddress { get; private set; }
    public List<Contract> Contracts { get; private set; }

    private Employee(string firstName, string lastName, Address employeeAddress, Contract contract) : base()
    {
        Code = Guid.NewGuid().ToString();
        FirstName = firstName;
        LastName = lastName;
        EmployeeAddress = employeeAddress;
        Contracts = new List<Contract> { contract };
    }

    public static Employee Create(string firstName, string lastName, Address address, Contract contract)
    {
        var employee = new Employee(firstName, lastName, address, contract); 

        return employee;
    }
}