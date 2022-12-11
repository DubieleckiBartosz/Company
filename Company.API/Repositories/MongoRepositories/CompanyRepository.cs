using Company.API.Common.Constants;
using Company.API.Interfaces.RepositoryInterfaces;
using Company.API.Models.Documents;
using MongoDB.Driver;

namespace Company.API.Repositories.MongoRepositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly MongoContext _context;
    private readonly IMongoCollection<Models.Documents.Company> _companyCollection;
    public CompanyRepository(MongoContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _companyCollection ??= _context.GetCollection<Models.Documents.Company>(Collections.CompanyCollection);
    }
    public async Task AddAsync(Models.Documents.Company company)
    {
        await _companyCollection.InsertOneAsync(company);  
    }

    public async Task AddDepartmentAsync(Models.Documents.Company company)
    {
        var newDepartment = company.Departments.Last();

        var companyCollection = _context.GetCollection<Models.Documents.Company>(Collections.CompanyCollection);

        var idFilter = Builders<Models.Documents.Company>.Filter.Eq(_ => _.Id, company.Id);
        var update = Builders<Models.Documents.Company>.Update.Push(_ => _.Departments, newDepartment);

        await companyCollection.FindOneAndUpdateAsync(idFilter, update);
    }

    public async Task<Models.Documents.Company> GetByIdAsync(string id)
    {
        var companyCollection = _context.GetCollection<Models.Documents.Company>(Collections.CompanyCollection);
        var idFilter = Builders<Models.Documents.Company>.Filter.Eq(_ => _.Id, id);

        return await companyCollection.Find(idFilter).FirstOrDefaultAsync();
    } 

    public async Task<Models.Documents.Company> GetByIdDetailsAsync(string id)
    { 
        throw new NotImplementedException();
        //Department.Load(y.Id, y.Name, y.DepartmentType)
    }

    public async Task<Models.Documents.Company> GetCompaniesBySearchAsync(string id)
    {
        throw new NotImplementedException();
    }
}

