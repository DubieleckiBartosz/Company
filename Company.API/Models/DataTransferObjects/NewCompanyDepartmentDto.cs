using Company.API.Models.DataParameters;
using Company.API.Models.Enums;

namespace Company.API.Models.DataTransferObjects;

public record NewCompanyDepartmentDto(string CompanyId, DepartmentType DepartmentType, string Name)
{
    public static NewCompanyDepartmentDto Create(NewCompanyDepartmentParameters parameters)
    {
        return new NewCompanyDepartmentDto(parameters.CompanyId, parameters.DepartmentType, parameters.Name);
    }
}