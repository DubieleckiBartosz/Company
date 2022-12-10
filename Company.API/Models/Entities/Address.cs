namespace Company.API.Models.Entities;

public class Address 
{ 
    public Guid Id { get; private set; }
    public string City { get; set; }
    public string PostalCode { get; set; }
    public string Street { get; set; }

    public Address(string city, string postalCode, string street)
    {
        Id = Guid.NewGuid();
        City = city;
        PostalCode = postalCode;
        Street = street;
    }
}