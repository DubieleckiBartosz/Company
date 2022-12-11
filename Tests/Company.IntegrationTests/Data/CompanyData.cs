using Bogus; 
using Company.API.Models.Documents;
using Company.API.Models.Enums;

namespace Company.IntegrationTests.Data;

internal class CompanyData
{
    private const string Locale = "pl"; 
    public static List<API.Models.Documents.Company> GetCompanies(int count)
    {
        var rnd = new Random();

        var companies = new Faker<API.Models.Documents.Company>(Locale)
            .RuleFor(r => r.Name, _ => _.Company.CompanyName())
            .RuleFor(r => r.Description, _ => _.Company.CatchPhrase())
            .RuleFor(r => r.Created, _ => DateTime.UtcNow.AddMonths(-rnd.Next(1, 100)))
            .RuleFor(r => r.Address,
                _ => Address.Create(_.Address.City(), _.Address.ZipCode(), _.Address.StreetAddress()))
            .RuleFor(r=> r.Departments, (f, u) =>
            {
                var departments = new Faker<Department>(Locale)
                    .RuleFor(r => r.Name, _ => _.Commerce.Department()).Generate(2);

                departments.ForEach(_ =>
                {
                    var employees = GetEmployees();

                    foreach (var employee in employees)
                    {
                        _.AddNewEmployee(employee);
                    }

                    if (u?.Departments == null || u.Departments.Any() == false)
                    {
                        u?.NewDepartment(_.Name, DepartmentType.IT);
                    }
                    else
                    {
                        u?.NewDepartment(_.Name, DepartmentType.Production);
                    }
                });

                return departments;
            }).Generate(count); 

        return companies;
    }

    public static List<Employee> GetEmployees()
    {
        var rnd = new Random();

        var employees = new Faker<Employee>(Locale)
            .RuleFor(r => r.FirstName, (f, u) => f.Name.FirstName())
            .RuleFor(r => r.LastName, (f, u) => f.Name.LastName())
            .RuleFor(r => r.Code, _ => _.UniqueIndex.ToString() + Guid.NewGuid().ToString())
            .RuleFor(r => r.EmployeeAddress,
                _ => Address.Create(_.Address.City(), _.Address.ZipCode(), _.Address.StreetAddress()))
            .RuleFor(r => r.Contracts, _ =>
            {
                var contracts = new Faker<Contract>(Locale)
                    .RuleFor(r => r.ContractType, _ => _.PickRandom<ContractType>())
                    .RuleFor(r => r.HoursPerMonth, rnd.Next(120, 180))
                    .RuleFor(r => r.Salary, rnd.Next(1500, 10000))
                    .Generate(2);
                return contracts;
            })
            .Generate(10);

        return employees;
    }
}