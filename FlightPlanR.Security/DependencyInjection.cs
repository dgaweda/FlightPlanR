using FlightPlanApi.Common.Authentication;
using FlightPlanR.Application.Services;
using FlightPlanR.Security.Services.CurrentUser;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightPlanR.Security;

public static class DependencyInjection
{
  public static IServiceCollection AddSecurityServices(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddJwt(configuration);
    services.AddHttpContextAccessor();
    services.AddSingleton<ICurrentUserService, CurrentUserService>();
    services.AddScoped<IUserService, UserService>();
    
    return services;
  }
}