using FlightPlanApi.Models;
using FlightPlanR.DataAccess.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization.Conventions;

namespace FlightPlanR.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessDI(this IServiceCollection services, IConfiguration configuration)
    {
        ConventionRegistry.Register("Ignore", new ConventionPack
        {
            new IgnoreIfDefaultConvention(true),
            new IgnoreExtraElementsConvention(true)
        }, _ => true);
        services.Configure<MongoConfiguration>(configuration.GetSection("Database:MongoDB").Bind);
        services.AddScoped<IFlightPlanRepository, FlightPlanRepository>();
        return services;
    }
}