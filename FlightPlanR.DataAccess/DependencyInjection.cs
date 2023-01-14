using FlightPlanApi.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightPlanR.DataAccess;

public static class DependencyInjection
{
    public static IServiceCollection AddDataAccessDI(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IDatabaseAdapter, MongoDbDatabase>();
        return services;
    }
}