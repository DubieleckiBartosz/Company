using Company.IntegrationTests.Data;
using MongoDB.Driver;

namespace Company.IntegrationTests.Generators;

public class CompanyGeneratorData 
{
    private const string CollectionName = "Companies";
    private readonly IMongoDatabase _database;
    public CompanyGeneratorData() 
    {
        _database = new MongoClient("mongodb://rootuser:rootpass@localhost:27015").GetDatabase("CE");
    }

    [Fact]
    public async Task GenerateCompaniesWithDetails()
    {
        var companies = CompanyData.GetCompanies(5);
        var companyCollection = _database.GetCollection<API.Models.Documents.Company>(CollectionName);
        await companyCollection.InsertManyAsync(companies);
    }
}