using Company.API.Common.Exceptions;
using Company.API.Interfaces.RepositoryInterfaces;
using Company.API.Interfaces.ServiceInterfaces;
using Company.API.Models.DataTransferObjects;
using Company.API.Models.Documents;

namespace Company.API.Services;

public class DepartmentService : IDepartmentService
{

    private readonly ICompanyRepository _companyRepository;

    public DepartmentService(IWrapperRepository wrapperRepository)
    {
        _companyRepository = wrapperRepository.CompanyRepository;
    }

    public async Task AddNewEmployeeAsync(NewDepartmentEmployeeDto employeeDto)
    {
        var department =
            await _companyRepository.GetDepartmentFromCompanyByCodeAsync(employeeDto.CompanyId,
                employeeDto.DepartmentCode);

        if (department == null)
        {
            throw new NotFoundException();
        }

        var address = Address.Create(employeeDto.City, employeeDto.PostalCode, employeeDto.Street);
        var contract = Contract.Create(employeeDto.Salary, employeeDto.Start, employeeDto.End,
            employeeDto.HoursPerMonth, employeeDto.ContractType);
        var newEmployee = Employee.Create(employeeDto.FirstName, employeeDto.LastName, address, contract);

        department.AddNewEmployee(newEmployee);

        await _companyRepository.AddEmployeeToDepartmentAsync(employeeDto.CompanyId, department);
    }
}