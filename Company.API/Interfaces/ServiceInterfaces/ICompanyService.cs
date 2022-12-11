using Company.API.Models.DataTransferObjects;
using Company.API.Models.Views;
using Company.API.Wrappers;

namespace Company.API.Interfaces.ServiceInterfaces;

public interface ICompanyService
{
    Task<Response<string>> CreateNewCompanyAsync(NewCompanyDto newCompanyDto);
    Task AddNewDepartmentAsync(NewCompanyDepartmentDto newCompanyDepartmentDto);
    Task<Response<CompanyView>> GetByIdAsync(string id);
    Task<Response<CompanyWithDepartmentsView>> GetByIdWithDepartmentsAsync(string id);
    Task<CompanyView> GetByIdDetailsAsync(string id);
    Task<CompanyView> GetCompaniesBySearchAsync(string id);
}