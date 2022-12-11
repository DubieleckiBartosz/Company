using Company.API.Repositories.MongoRepositories; 

namespace Company.API.Interfaces.RepositoryInterfaces;

public interface ICompanyRepository
{
    Task AddAsync(Models.Documents.Company company);
    Task AddDepartmentAsync(Models.Documents.Company company);
    Task<Models.Documents.Company> GetByIdAsync(string id); 
    Task<Models.Documents.Company> GetByIdDetailsAsync(string id);
    Task<Models.Documents.Company> GetCompaniesBySearchAsync(string id); 
    CompanyEmployeeRepository CompanyEmployeeAccess();
    CompanyDepartmentRepository CompanyDepartmentAccess();
}