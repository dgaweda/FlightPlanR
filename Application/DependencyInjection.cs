using FlightPlanR.Application.Common.Security;
using FlightPlanR.Application.Services.Account;
using FlightPlanR.Application.Services.FlightPlan;
using FlightPlanR.Application.Services.User;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightPlanR.Application;

public static class DependencyInjection
{
  public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    services.AddJSONWebTokenAuthentication(configuration);
    services.AddScoped<IFlightPlanService, FlightPlanService>();
    services.AddScoped<IUserService, UserService>();
    services.AddScoped<IAccountService, AccountService>();
    
    return services;
  }
}