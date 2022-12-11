using Company.API.Models.Documents;

namespace Company.API.Models.Views;

public record EmployeeView(string Code, string FirstName, string LastName, AddressView EmployeeAddress)
{
    public static EmployeeView Create(Employee employee)
    {
        var address = AddressView.Create(employee.EmployeeAddress);
        return new EmployeeView(employee.Code, employee.FirstName, employee.LastName, address);
    }
}