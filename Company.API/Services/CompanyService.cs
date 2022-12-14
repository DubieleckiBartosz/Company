using Company.API.Common.Exceptions;
using Company.API.Interfaces.RepositoryInterfaces;
using Company.API.Interfaces.ServiceInterfaces;
using Company.API.Models.DataTransferObjects;
using Company.API.Models.Documents;
using Company.API.Models.Searches.Queries;
using Company.API.Models.Views;
using Company.API.Wrappers;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Company.API.Services;

public class CompanyService : ICompanyService
{
    private readonly ICompanyRepository _companyRepository;

    public CompanyService(IWrapperRepository wrapperRepository)
    {
        _companyRepository = wrapperRepository.CompanyRepository;
    }
    public async Task<Response<string>> CreateNewCompanyAsync(NewCompanyDto newCompanyDto)
    {
        var address = Address.Create(newCompanyDto.City, newCompanyDto.PostalCode, newCompanyDto.Street);
        var newCompany = Models.Documents.Company.Create(newCompanyDto.Name, newCompanyDto.Description, address);

        await _companyRepository.AddAsync(newCompany);

        return Response<string>.Ok(newCompany.Id);
    }

    public async Task AddNewDepartmentAsync(NewCompanyDepartmentDto newCompanyDepartmentDto)
    {
        var companyWithDepartments =
            await _companyRepository.GetByIdAsync(newCompanyDepartmentDto.CompanyId);

        companyWithDepartments.NewDepartment(newCompanyDepartmentDto.Name, newCompanyDepartmentDto.DepartmentType);
        await _companyRepository.AddDepartmentAsync(companyWithDepartments);
    }

    public async Task<Response<CompanyView>> GetByIdAsync(string id)
    {
        var result = await _companyRepository.GetByIdAsync(id);
        var companyDto = CompanyView.MapFromCompany(result);

        return Response<CompanyView>.Ok(companyDto);
    }

    public async Task<Response<CompanyWithDepartmentsView>> GetByIdWithDepartmentsAsync(string id)
    {
        var company = await _companyRepository.GetByIdAsync(id);
        if (company == null)
        {
            throw new NotFoundException();
        }

        var companyWithDepartments = CompanyWithDepartmentsView.MapFromCompany(company);

        return Response<CompanyWithDepartmentsView>.Ok(companyWithDepartments);
    }

    public async Task<Response<CompanyDetailsView>> GetByIdDetailsAsync(string id)
    {
        var company = await _companyRepository.GetByIdAsync(id);
        if (company == null)
        {
            throw new NotFoundException();
        }

        var companyView = CompanyDetailsView.Create(company);

        return Response<CompanyDetailsView>.Ok(companyView);
    }

    public async Task<Response<List<CompanyView>>> GetCompaniesBySearchAsync(GetCompaniesBySearchQuery query)
    {
        var companies = await _companyRepository.GetCompaniesBySearchAsync(query.Sort.Name, query.Sort.Type,
            query.SearchQuery.PageNumber, query.SearchQuery.PageSize, query.Id, query.Name);
        if (companies == null || companies.Any() == false)
        {
            throw new NotFoundException();
        }
        var companyView = companies.Select(CompanyView.MapFromCompany).ToList(); 

        return Response<List<CompanyView>>.Ok(companyView);
    }
}

