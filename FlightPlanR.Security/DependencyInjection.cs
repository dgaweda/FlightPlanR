using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Security.Authentication;
using Security.Services.Authenticate;
using Security.Services.CurrentUser;

namespace Security;

public static class DependencyInjection
{
  public static IServiceCollection AddSecurityServices(this IServiceCollection services, IConfiguration configuration)
  {
    services.AddJwt(configuration);
    services.AddHttpContextAccessor();
    services.AddSingleton<ICurrentUserService, CurrentUserService>();
    services.AddScoped<IAuthenticationService, AuthenticationService>();
    services.AddScoped<IJwtHandler, JwtHandler>();
    
    return services;
  }
}