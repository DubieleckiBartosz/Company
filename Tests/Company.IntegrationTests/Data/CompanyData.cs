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
        var companyCreated = DateTime.UtcNow.AddMonths(-rnd.Next(1, 100));
        var companies = new Faker<API.Models.Documents.Company>(Locale)
            .RuleFor(r => r.Name, _ => _.Company.CompanyName())
            .RuleFor(r => r.Description, _ => _.Company.CatchPhrase())
            .RuleFor(r => r.Created, _ => companyCreated)
            .RuleFor(r => r.Address,
                _ => Address.Create(_.Address.City(), _.Address.ZipCode(), _.Address.StreetAddress()))
            .RuleFor(r=> r.Departments, (f, u) =>
            {
                var departments = new Faker<Department>(Locale)
                    .RuleFor(r => r.Name, _ => _.Commerce.Department()).Generate(2);

                departments.ForEach(_ =>
                {
                    var employees = GetEmployees(u.Created);

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

    public static List<Employee> GetEmployees(DateTime companyCreated)
    {
        var cnt = 10;
        var rnd = new Random();
         
        var employees = new Faker<Employee>(Locale)
            .RuleFor(r => r.FirstName, (f, u) => f.Name.FirstName())
            .RuleFor(r => r.LastName, (f, u) => f.Name.LastName())
            .RuleFor(r => r.Code, _ => _.UniqueIndex.ToString() + Guid.NewGuid().ToString())
            .RuleFor(r => r.EmployeeAddress,
                _ => Address.Create(_.Address.City(), _.Address.ZipCode(), _.Address.StreetAddress()))
            .RuleFor(r => r.Contracts, _ =>
            {
                var contracts = new List<Contract>();
                for (var i = 0; i < 2; i++)
                {
                    var date = companyCreated.AddMonths(GetStartContract(companyCreated));
                    var contract = new Faker<Contract>(Locale)
                        .RuleFor(r => r.ContractType, _ => _.PickRandom<ContractType>())
                        .RuleFor(r => r.HoursPerMonth, rnd.Next(120, 180))
                        .RuleFor(r => r.Salary, rnd.Next(1500, 10000))
                        .RuleFor(r => r.Start, date)
                        .Generate();

                    contracts.Add(contract);
                }
        
                return contracts;
            })
            .Generate(cnt);

        return employees;
    }

    private static int GetStartContract(DateTime companyCreated)
    {
        var rnd = new Random();

        var result = Math.Abs((int)Math.Ceiling(companyCreated.Subtract(DateTime.UtcNow).TotalDays / 30));

       if (InRange(result, 1, 10))
       {
           return 1;
       }

       if (InRange(result, 11, 20))
       {
           return rnd.Next(1, 11);
       }

       if (InRange(result, 21, 30))
       {
           return rnd.Next(12, 21);
       }

       if (InRange(result, 31, 40))
       {
           return rnd.Next(22, 31);
       }

       if (InRange(result, 41, 50))
       {
           return rnd.Next(32, 41);
       }

       if (InRange(result, 51, 60))
       {
           return rnd.Next(42, 51);
       }

       return rnd.Next(52, 61); 
    }

    private static bool InRange(int item, int from, int to) => item > from && item <= to;
}