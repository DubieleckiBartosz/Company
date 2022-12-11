using Company.API.Common.Exceptions;
using Company.API.Models.Enums;

namespace Company.API.Models.Documents;

public class Company : Document
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Address Address { get; private set; }
    public List<Department> Departments { get; private set; } = new List<Department>();

    public Company()
    {
    }
    private Company(string name, string description, Address address) : base()
    {
        Name = name;
        Description = description;
        Address = address; 
        Departments = new List<Department>();
    }

    public static Company Create(string name, string description, Address address)
    {
        return new Company(name, description, address);
    }

    public void NewDepartment(string name, DepartmentType departmentType)
    {
        var alreadyExists = Departments.Any(_ => _.Name == name);
        if (alreadyExists)
        {
            throw new CompanyAppBusinessException();
        }

        var department = Department.Create(name, departmentType); 
        Departments.Add(department);
    }
}