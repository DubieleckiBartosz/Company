using Company.API.Models.Documents;

namespace Company.API.Interfaces.RepositoryInterfaces;

public interface ICompanyRepository
{
    Task AddAsync(Models.Documents.Company company);
    Task AddDepartmentAsync(Models.Documents.Company company);
    Task<Models.Documents.Company> GetByIdAsync(string id); 
    Task<Models.Documents.Company> GetByIdDetailsAsync(string id);
    Task<Models.Documents.Company> GetCompaniesBySearchAsync(string id);
    Task AddEmployeeToDepartmentAsync(string companyId, Department department);
    Task<Department?> GetDepartmentFromCompanyByCodeAsync(string companyId, string departmentCode);
}