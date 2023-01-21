using FlightPlanR.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FlightPlanR.Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services)
  {
    services.AddScoped<IFlightPlanService, FlightPlanService>();
    services.AddScoped<IUserService, UserService>();
    return services;
  }
}