using Company.API.Common.Constants;
using Company.API.Interfaces.RepositoryInterfaces; 
using MongoDB.Driver; 

namespace Company.API.Repositories.MongoRepositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly MongoContext _context;
    private readonly IMongoCollection<Models.Documents.Company> _companyCollection;
    public CompanyRepository(MongoContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _companyCollection ??= _context.GetCollection<Models.Documents.Company>(MongoConstants.CompanyCollection);
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
    public async Task<Models.Documents.Company> GetByIdDetailsAsync(string id)
    { 
        throw new NotImplementedException(); 
    }

    public async Task<Models.Documents.Company> GetCompaniesBySearchAsync(string id)
    {
        throw new NotImplementedException();
    }

    public CompanyEmployeeRepository CompanyEmployeeAccess () =>
        new CompanyEmployeeRepository(companyCollection: _companyCollection);
    
    public CompanyDepartmentRepository CompanyDepartmentAccess () =>
        new CompanyDepartmentRepository(companyCollection: _companyCollection);

    private FilterDefinition<Models.Documents.Company> FilterCompany(string id) =>
        Builders<Models.Documents.Company>.Filter.Eq(_ => _.Id, id);
}

