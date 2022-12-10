using Company.API.Interfaces.RepositoryInterfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Company.API.Repositories.MongoRepositories;

public class CompanyRepository : ICompanyRepository
{
    public Task<Models.Entities.Company> GetByIdAsync(Guid id)
    {
        IAsyncCursor<Models.Entities.Company> query = entities.Aggregate()
            .Match(p => listNames.Contains(p.name))
            .Lookup(
                foreignCollection: others,
                localField: e => e.id,
                foreignField: f => f.entity,
                @as: (EntityWithOthers eo) => eo.others
            )
            .Project(p => new { p.id, p.name, other = p.others.First() })
            .Sort(new BsonDocument("other.name", -1))
            .ToList();
    }

    public Task<Models.Entities.Company> GetByIdWithDepartmentsAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Models.Entities.Company> GetByIdDetailsAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Models.Entities.Company> GetCompaniesBySearchAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}