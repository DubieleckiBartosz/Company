using Company.API.Models.DataParameters;

namespace Company.API.Models.DataTransferObjects;

public record NewCompanyDto(string Name, string Description, string City, string PostalCode, string Street)
{
    public static NewCompanyDto Create(NewCompanyParameters parameters)
    {
        return new NewCompanyDto(parameters.Name, parameters.Description, parameters.City, parameters.PostalCode, parameters.Street);
    }
}