using Company.API.Models.Enums;

namespace Company.API.Models.Entities;

public class Company : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public Address Address { get; private set; }
    public List<Department> Departments { get; private set; }

    public Company(string name, string description, Address address)
    {
        Name = name;
        Description = description;
        Address = address;
        Departments = new List<Department>();
    }

    public Guid NewDepartment(string name, DepartmentType departmentType)
    {
        var alreadyExists = Departments.Any(_ => _.Name == name);
        if (alreadyExists)
        {
            
        }

        var department = Department.Create(name, departmentType);
    } 
}