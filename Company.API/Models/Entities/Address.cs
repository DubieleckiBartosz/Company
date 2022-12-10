using MongoDB.Bson.Serialization.Attributes;

namespace Company.API.Models.Entities;

public class Address
{
    [BsonId]
    public Guid Id { get; private set; }
    public string City { get; private set; }
    public string PostalCode { get; private set; }
    public string Street { get; private set; }
    
    private Address(string city, string postalCode, string street)
    {
        Id = Guid.NewGuid();
        City = city;
        PostalCode = postalCode;
        Street = street;
    }

    public static Address Create(string city, string postalCode, string street)
    {
        return new Address(city, postalCode, street);
    }
}