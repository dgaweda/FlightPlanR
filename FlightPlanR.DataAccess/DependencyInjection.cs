using FlightPlanApi.Common.Configuration;
using FlightPlanR.DataAccess.Repositories.FlightPlanRepository;
using FlightPlanR.DataAccess.Repositories.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;

namespace FlightPlanR.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        ConventionRegistry.Register("Ignore", new ConventionPack
        {
            new IgnoreIfDefaultConvention(true)
        }, _ => true);

        var mongoConfig = new MongoConfiguration();
        configuration.Bind("Database:MongoDB", mongoConfig);
        
        services.AddSingleton(mongoConfig);
        services.AddSingleton<IMongoClient>(new MongoClient(mongoConfig.ConnectionString));

        services.AddScoped<IFlightPlanRepository, FlightPlanRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}