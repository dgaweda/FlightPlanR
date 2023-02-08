using FlightPlanR.Infrastructure.Common.Configuration;
using FlightPlanR.Infrastructure.Repository.FlightPlanRepository;
using FlightPlanR.Infrastructure.Repository.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace FlightPlanR.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        var mongoConfig = new MongoConfiguration();
        configuration.Bind("Database:MongoDB", mongoConfig);
        
        services.AddSingleton(mongoConfig);
        services.AddSingleton<IMongoClient>(new MongoClient(mongoConfig.ConnectionString));

        services.AddScoped<IFlightPlanRepository, FlightPlanRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }
}