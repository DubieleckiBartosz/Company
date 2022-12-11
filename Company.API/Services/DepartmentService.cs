using Company.API.Common.Exceptions;
using Company.API.Interfaces.RepositoryInterfaces;
using Company.API.Interfaces.ServiceInterfaces;
using Company.API.Models.DataTransferObjects;
using Company.API.Models.Documents;
using Company.API.Repositories.MongoRepositories;

namespace Company.API.Services;

public class DepartmentService : IDepartmentService
{

    private readonly CompanyDepartmentRepository _departmentRepository;

    public DepartmentService(IWrapperRepository wrapperRepository)
    {
        _departmentRepository = wrapperRepository.CompanyRepository.CompanyDepartmentAccess();
    }

    public async Task AddNewEmployeeAsync(NewDepartmentEmployeeDto employeeDto)
    {
        var department =
            await _departmentRepository.GetDepartmentFromCompanyByCodeAsync(employeeDto.CompanyId,
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

        await _departmentRepository.AddEmployeeToDepartmentAsync(employeeDto.CompanyId, department);
    }
}