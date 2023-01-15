using FlightPlanApi.Models;
using FlightPlanR.DataAccess.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightPlanR.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessDI(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoConfiguration>(configuration.GetSection("Database:MongoDB").Bind);
        services.AddScoped<IFlightPlanRepository, FlightPlanRepository>();
        return services;
    }
}