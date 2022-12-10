using Company.API.Repositories.MongoRepositories;

namespace Company.API.Configurations;

public static class DependencyInjection
{
    public static WebApplicationBuilder GetDependencyInjection(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<MongoContext>();

        return builder;
    }
}