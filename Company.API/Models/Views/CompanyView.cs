namespace Company.API.Models.Views;

public record CompanyView(string Identifier, string Description, string Name, AddressView Address)
{
    public static CompanyView MapFromCompany(Documents.Company company)
    {
        var address = AddressView.Create(company.Address);
        return new CompanyView(company.Id, company.Description, company.Name, address);
    }
}