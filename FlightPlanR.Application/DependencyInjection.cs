using FlightPlanR.Application.Services;
using FlightPlanR.Application.Services.FlightPlan;
using Microsoft.Extensions.DependencyInjection;

namespace FlightPlanR.Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services)
  {
    services.AddScoped<IFlightPlanService, FlightPlanService>();
    return services;
  }
}