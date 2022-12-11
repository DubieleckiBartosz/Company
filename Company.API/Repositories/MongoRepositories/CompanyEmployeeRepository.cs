using Company.API.Common.Constants;
using MongoDB.Driver;

namespace Company.API.Repositories.MongoRepositories;

public class CompanyEmployeeRepository
{
    private readonly IMongoCollection<Models.Documents.Company> _companyCollection;
    public CompanyEmployeeRepository(IMongoCollection<Models.Documents.Company> companyCollection)
    {
        _companyCollection = companyCollection;
    }
}