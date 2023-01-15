using FlightPlanApi.Models;
using FlightPlanR.DataAccess.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightPlanR.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        var mongoConfiguration = new MongoConfiguration();
        configuration.GetSection("Database.MongoDB").Bind(mongoConfiguration);
        
        services.AddSingleton<IMongoConfiguration, MongoConfiguration>();
        
        services.AddScoped<IRepository<FlightPlan>, Repository<FlightPlan>>();
        services.AddScoped<IFlightPlanRepository, FlightPlanRepository>();
        return services;
    }
}