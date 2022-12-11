using Company.API.Models.Documents;
using MongoDB.Driver;

namespace Company.API.Repositories.MongoRepositories;

public class CompanyDepartmentRepository
{ 
    private readonly IMongoCollection<Models.Documents.Company> _companyCollection;
    public CompanyDepartmentRepository(IMongoCollection<Models.Documents.Company> companyCollection)
    {
        _companyCollection = companyCollection;
    }

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
        var department = await _companyCollection.Find(Builders<Models.Documents.Company>.Filter.Eq(_ => _.Id, companyId))
            .Project(_ => _.Departments.FirstOrDefault(_ => _.DepartmentUniqueCode == departmentCode)).FirstOrDefaultAsync();

        return department;
    }
}