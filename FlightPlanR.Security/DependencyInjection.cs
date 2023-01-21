using FlightPlanApi.Common.Authentication;
using FlightPlanR.Security.Services.CurrentUser;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FlightPlanR.Security;

public static class DependencyInjection
{
  public static IServiceCollection AddSecurityDI(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddJwt(configuration);
    services.AddHttpContextAccessor();
    services.AddSingleton<ICurrentUserService, CurrentUserService>();
    return services;
  }
}