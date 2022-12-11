using Company.API.Models.DataTransferObjects;

namespace Company.API.Interfaces.ServiceInterfaces;

public interface IDepartmentService
{
    Task AddNewEmployeeAsync(NewDepartmentEmployeeDto employeeDto);
}