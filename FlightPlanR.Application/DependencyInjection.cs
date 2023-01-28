using FlightPlanR.Application.Services.FlightPlan;
using FlightPlanR.Application.Services.User;
using Microsoft.Extensions.DependencyInjection;

namespace FlightPlanR.Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services)
  {
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    services.AddScoped<IFlightPlanService, FlightPlanService>();
    services.AddScoped<IUserService, UserService>();
    return services;
  }
}