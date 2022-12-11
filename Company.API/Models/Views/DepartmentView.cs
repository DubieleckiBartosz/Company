using Company.API.Models.Documents;
using Company.API.Models.Enums;

namespace Company.API.Models.Views;

public record DepartmentView(string DepartmentUniqueCode, DepartmentType DepartmentType, string Name)
{
    public static DepartmentView Create(Department department)
    {
        return new DepartmentView(department.DepartmentUniqueCode, department.DepartmentType, department.Name);
    }
}