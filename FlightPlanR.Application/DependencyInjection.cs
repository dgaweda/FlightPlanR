using FlightPlanR.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FlightPlanR.Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplicationDI(this IServiceCollection services)
  {
    services.AddScoped<IFlightPlanService, FlightPlanService>();
    return services;
  }
}