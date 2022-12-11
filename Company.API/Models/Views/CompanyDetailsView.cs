namespace Company.API.Models.Views;

public record CompanyDetailsView(string Description, string Name, AddressView Address, List<DepartmentWithEmployeesView> Departments)
{
    public static CompanyDetailsView Create(Documents.Company company)
    {
        var address = AddressView.Create(company.Address);
        var departments = company.Departments.Select(DepartmentWithEmployeesView.Create).ToList();

        return new CompanyDetailsView(company.Description, company.Name, address, departments);
    }
}