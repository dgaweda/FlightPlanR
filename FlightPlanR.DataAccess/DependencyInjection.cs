using FlightPlanApi.Models;
using FlightPlanR.DataAccess.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightPlanR.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IMongoConfiguration, MongoConfiguration>();
        services.Configure<IMongoConfiguration>(configuration.GetSection("Database:MongoDB"));
        // services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IFlightPlanRepository, FlightPlanRepository>();
        return services;
    }
}