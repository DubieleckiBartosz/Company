using Company.API.Models.DataParameters;
using Company.API.Models.Enums;

namespace Company.API.Models.DataTransferObjects;

public record NewDepartmentEmployeeDto(string CompanyId, string DepartmentCode, string FirstName, string LastName,
    decimal Salary,
    DateTime Start, DateTime? End, int HoursPerMonth, ContractType ContractType, string City, string PostalCode,
    string Street)
{
    public static NewDepartmentEmployeeDto Create(string companyId, NewDepartmentEmployeeParameters parameters)
    {
        return new NewDepartmentEmployeeDto(companyId, parameters.DepartmentCode, parameters.FirstName,
            parameters.LastName,
            parameters.Salary, parameters.Start, parameters.End, parameters.HoursPerMonth, parameters.ContractType,
            parameters.City, parameters.PostalCode, parameters.Street);
    }
}