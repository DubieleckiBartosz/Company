using Company.API.Common.Exceptions;
using Company.API.Models.Enums;

namespace Company.API.Models.Entities;

public class Company : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Address Address { get; private set; }
    public List<Department> Departments { get; private set; }

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

    public Guid NewDepartment(string name, DepartmentType departmentType)
    {
        var alreadyExists = Departments.Any(_ => _.Name == name);
        if (alreadyExists)
        {
            throw new CompanyAppBusinessException();
        }

        var department = Department.Create(name, departmentType);
        return department.Id;
    } 
}