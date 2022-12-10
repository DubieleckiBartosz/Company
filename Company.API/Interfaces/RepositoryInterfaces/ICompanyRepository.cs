namespace Company.API.Interfaces.RepositoryInterfaces;

public interface ICompanyRepository
{
    Task<Models.Entities.Company> GetByIdAsync(Guid id);
    Task<Models.Entities.Company> GetByIdWithDepartmentsAsync(Guid id);
    Task<Models.Entities.Company> GetByIdDetailsAsync(Guid id);
    Task<Models.Entities.Company> GetCompaniesBySearchAsync(Guid id); 
}