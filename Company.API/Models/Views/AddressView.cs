using Company.API.Models.Documents;

namespace Company.API.Models.Views;

public record AddressView(string City, string PostalCode, string Street)
{
    public static AddressView Create(Address address)
    {
        return new AddressView(address.City, address.PostalCode, address.Street);
    }
}