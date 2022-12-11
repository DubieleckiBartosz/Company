using Company.API.Models.Enums;

namespace Company.API.Models.DataParameters;

public record NewCompanyDepartmentParameters(string CompanyId, DepartmentType DepartmentType, string Name);