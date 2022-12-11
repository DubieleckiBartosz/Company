namespace Company.API.Models.Views;

public record CompanyWithDepartmentsView(string Description, string Name, AddressView Address, List<DepartmentView> Departments)
{
    public static CompanyWithDepartmentsView MapFromCompany(Documents.Company company)
    {
        var address = AddressView.Create(company.Address);
        var departments = company.Departments.Select(DepartmentView.Create).ToList();
        return new CompanyWithDepartmentsView(company.Description, company.Name, address, departments);
    }
}