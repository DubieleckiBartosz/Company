using Company.API.Options;

namespace Company.API.Configurations;

public static class OptionConfiguration
{
    public static WebApplicationBuilder SetOptions(this WebApplicationBuilder builder)
    {
        var config = builder.Configuration;
        builder.Services.Configure<MongoConnections>(config.GetSection("MongoConnections"));

        return builder;
    }
}