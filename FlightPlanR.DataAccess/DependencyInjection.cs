using FlightPlanApi.Common.Configuration;
using FlightPlanR.DataAccess.Repositories.FlightPlanRepository;
using FlightPlanR.DataAccess.Repositories.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Conventions;

namespace FlightPlanR.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        ConventionRegistry.Register("Ignore", new ConventionPack
        {
            new IgnoreIfDefaultConvention(true),
            new IgnoreExtraElementsConvention(true)
        }, _ => true);
        services.Configure<MongoConfiguration>(configuration.GetSection("Database:MongoDB").Bind);
        
        services.AddScoped<IFlightPlanRepository>(sp => new FlightPlanRepository(sp.GetRequiredService<IOptions<MongoConfiguration>>(),"flight_plans"));
        services.AddScoped<IUserRepository>(sp => new UserRepository(sp.GetRequiredService<IOptions<MongoConfiguration>>(),"user"));
        return services;
    }
}