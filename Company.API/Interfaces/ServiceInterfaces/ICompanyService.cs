using Company.API.Models.DataTransferObjects;
using Company.API.Models.Searches.Queries;
using Company.API.Models.Views;
using Company.API.Wrappers;

namespace Company.API.Interfaces.ServiceInterfaces;

public interface ICompanyService
{
    Task<Response<string>> CreateNewCompanyAsync(NewCompanyDto newCompanyDto);
    Task AddNewDepartmentAsync(NewCompanyDepartmentDto newCompanyDepartmentDto);
    Task<Response<CompanyView>> GetByIdAsync(string id);
    Task<Response<CompanyWithDepartmentsView>> GetByIdWithDepartmentsAsync(string id);
    Task<Response<CompanyDetailsView>> GetByIdDetailsAsync(string id);
    Task<Response<List<CompanyView>>> GetCompaniesBySearchAsync(GetCompaniesBySearchQuery query);
}