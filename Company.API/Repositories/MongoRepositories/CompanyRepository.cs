using Company.API.Common.Constants;
using Company.API.Interfaces.RepositoryInterfaces;
using Company.API.Models.Documents;
using MongoDB.Bson;
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


    //DEPARTMENT Operations
    public async Task AddEmployeeToDepartmentAsync(string companyId, Department department)
    {
        var newEmployee = department.Employees.Last();

        var filter = Builders<Models.Documents.Company>.Filter.And(
            Builders<Models.Documents.Company>.Filter.Eq(_ => _.Id, companyId),
            Builders<Models.Documents.Company>.Filter.Eq("Departments.DepartmentUniqueCode",
                department.DepartmentUniqueCode));
        
        var update = Builders<Models.Documents.Company>.Update.Push("Departments.$.Employees", newEmployee);

        await _companyCollection.FindOneAndUpdateAsync(filter, update);
    }


    public async Task<Department?> GetDepartmentFromCompanyByCodeAsync(string companyId, string departmentCode)
    {  
        var department = await _companyCollection.Find(FilterCompany(companyId))
            .Project(_ => _.Departments.FirstOrDefault(_ => _.DepartmentUniqueCode == departmentCode)).FirstOrDefaultAsync();
         
        return department;
    }

    private FilterDefinition<Models.Documents.Company> FilterCompany(string id) =>
        Builders<Models.Documents.Company>.Filter.Eq(_ => _.Id, id);
}

