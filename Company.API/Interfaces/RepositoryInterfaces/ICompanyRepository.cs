using Company.API.Repositories.MongoRepositories;

namespace Company.API.Interfaces.RepositoryInterfaces;

public interface ICompanyRepository
{
    Task AddAsync(Models.Documents.Company company);
    Task AddDepartmentAsync(Models.Documents.Company company);
    Task<Models.Documents.Company> GetByIdAsync(string id);  
    Task<List<Models.Documents.Company>?> GetCompaniesBySearchAsync(string sortName, string type, int pageNumber,
        int pageSize, string? id, string? name);

    CompanyEmployeeRepository CompanyEmployeeAccess();
    CompanyDepartmentRepository CompanyDepartmentAccess();
}