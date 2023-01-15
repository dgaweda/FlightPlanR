using System.Reflection;
using System.Text.Json.Serialization;
using FlightPlanApi.Models;
using FlightPlanR.DataAccess.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Conventions;

namespace FlightPlanR.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        var mongoConfiguration = new MongoConfiguration();
        configuration.GetSection("Database.MongoDB").Bind(mongoConfiguration);
        services.AddSingleton<IMongoConfiguration, MongoConfiguration>();
        RegisterClassMapping();
        
        services.AddTransient<IRepository<FlightPlan>, Repository<FlightPlan>>();
        services.AddTransient<IFlightPlanRepository, FlightPlanRepository>();
        return services;
    }

    private static void RegisterClassMapping()
    {
        var conventionPack = new ConventionPack();
        conventionPack.AddMemberMapConvention("JsonPropertyNameMapping", m => m.MemberType.GetCustomAttribute<JsonPropertyNameAttribute>());
        ConventionRegistry.Register("Conventions", conventionPack, _ => true);
        
        BsonClassMap.RegisterClassMap<FlightPlan>(cm =>
        {
            cm.AutoMap();
        });
    }
}