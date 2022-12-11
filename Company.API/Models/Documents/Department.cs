using Company.API.Common.Exceptions;
using Company.API.Models.Enums;

namespace Company.API.Models.Documents;

public class Department : Base
{
    public string Name { get; private set; }
    public string DepartmentUniqueCode { get; private set; }
    public DepartmentType DepartmentType { get; private set; }
    public List<Employee> Employees { get; private set; }

    private Department(string name, DepartmentType departmentType) : base()
    {
        Name = name;
        DepartmentType = departmentType;
        DepartmentUniqueCode = Guid.NewGuid().ToString();
        Employees = new List<Employee>();
    }
     
    public static Department Create(string name, DepartmentType departmentType)
    {
        return new Department(name, departmentType);
    }
 
    public void AddNewEmployee(Employee employee)
    {
        var employeeAlreadyExists = Employees.Any(_ => _.Code == employee.Code);
        if (employeeAlreadyExists)
        {
            throw new CompanyAppBusinessException();
        }

        Employees.Add(employee);
    }
}