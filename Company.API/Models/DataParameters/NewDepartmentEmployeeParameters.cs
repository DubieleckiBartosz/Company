using Company.API.Models.Enums;

namespace Company.API.Models.DataParameters;

public record NewDepartmentEmployeeParameters(string DepartmentCode, string FirstName, string LastName, decimal Salary,
    DateTime Start, DateTime? End, int HoursPerMonth, ContractType ContractType, string City, string PostalCode,
    string Street);