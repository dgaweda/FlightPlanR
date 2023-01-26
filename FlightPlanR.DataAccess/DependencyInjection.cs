using FlightPlanApi.Common.Configuration;
using FlightPlanR.DataAccess.Repositories.CountryRepository;
using FlightPlanR.DataAccess.Repositories.DictionaryRepository;
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
        services.AddSingleton<MongoConfiguration>();

        services.AddScoped<IFlightPlanRepository, FlightPlanRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped(typeof(IDictionaryRepository<>), typeof(DictionaryRepository<>));
        return services;
    }
}