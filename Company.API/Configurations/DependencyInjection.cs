using Company.API.Interfaces.RepositoryInterfaces;
using Company.API.Interfaces.ServiceInterfaces;
using Company.API.Repositories.MongoRepositories;
using Company.API.Services;

namespace Company.API.Configurations;

public static class DependencyInjection
{
    public static WebApplicationBuilder GetDependencyInjection(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ICompanyService, CompanyService>();
        builder.Services.AddScoped<IDepartmentService, DepartmentService>();
        builder.Services.AddScoped<IWrapperRepository, WrapperRepository>();
        builder.Services.AddSingleton<MongoContext>();

        return builder;
    }
}