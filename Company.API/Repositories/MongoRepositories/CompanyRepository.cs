using Company.API.Common.Constants;
using Company.API.Helpers;
using Company.API.Interfaces.RepositoryInterfaces; 
using MongoDB.Driver; 

namespace Company.API.Repositories.MongoRepositories;

public class CompanyRepository : ICompanyRepository
{ 
    private readonly IMongoCollection<Models.Documents.Company> _companyCollection;
    public CompanyRepository(MongoContext context)
    {
        var mongoContext = context ?? throw new ArgumentNullException(nameof(context));
        _companyCollection ??= mongoContext.GetCollection<Models.Documents.Company>(MongoConstants.CompanyCollection);
    }
    public async Task AddAsync(Models.Documents.Company company)
    {
        await _companyCollection.InsertOneAsync(company);  
    }

    public async Task AddDepartmentAsync(Models.Documents.Company company)
    {
        var newDepartment = company.Departments.Last(); 
         
        var update = Builders<Models.Documents.Company>.Update.Push(_ => _.Departments, newDepartment);

        await _companyCollection.FindOneAndUpdateAsync(FilterCompany(company.Id), update);
    }

    public async Task<Models.Documents.Company> GetByIdAsync(string id)
    { 
        return await _companyCollection.Find(FilterCompany(id)).FirstOrDefaultAsync();
    }

    public async Task<List<Models.Documents.Company>?> GetCompaniesBySearchAsync(string sortName, string type,
        int pageNumber, int pageSize, string? id, string? name)
    {
        var filterBuilder = Builders<Models.Documents.Company>.Filter;
        var filter = filterBuilder.Empty;
        if (!string.IsNullOrWhiteSpace(id))
        {
            var sub = filterBuilder.Where(_ => _.Id == id);
            filter &= sub;
        } 

        var result = await _companyCollection.Aggregate()
            .Match(_ => _.Name == name)
            .Match(filter)
            .SortBy(SortHelpers.CompanySortBy(sortName))
            .Skip(pageSize * (pageNumber - 1))
            .Limit(pageSize)
            .ToListAsync(); 

        return result;
    }


    public CompanyEmployeeRepository CompanyEmployeeAccess () =>
        new CompanyEmployeeRepository(companyCollection: _companyCollection);
    
    public CompanyDepartmentRepository CompanyDepartmentAccess () =>
        new CompanyDepartmentRepository(companyCollection: _companyCollection);

    private FilterDefinition<Models.Documents.Company> FilterCompany(string id) =>
        Builders<Models.Documents.Company>.Filter.Eq(_ => _.Id, id);
}

