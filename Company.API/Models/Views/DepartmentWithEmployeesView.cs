using Company.API.Models.Documents;
using Company.API.Models.Enums;

namespace Company.API.Models.Views;

public record DepartmentWithEmployeesView(string DepartmentUniqueCode, DepartmentType DepartmentType, string Name, List<EmployeeView> Employees)
{
    public static DepartmentWithEmployeesView Create(Department department)
    {
        var employees = department.Employees.Select(EmployeeView.Create).ToList();
        return new DepartmentWithEmployeesView(department.DepartmentUniqueCode, department.DepartmentType, department.Name, employees);
    }
}