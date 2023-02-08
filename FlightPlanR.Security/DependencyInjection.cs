using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Security.Authentication;
using Security.Services.Authenticate;
using Security.Services.CurrentUser;

namespace Security;

public static class DependencyInjection
{
  private static readonly string JwtSection = "Jwt";
  public static IServiceCollection AddSecurityServices(this IServiceCollection services, IConfiguration configuration)
  {
    var jwtOptions = new JwtOptions();
    configuration.GetSection(JwtSection).Bind(jwtOptions);
		
    services.AddSingleton(jwtOptions);
    services.AddAuthentication(options =>
    {
      options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
      options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(options =>
    {
      options.RequireHttpsMetadata = false;
      options.SaveToken = true;
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidIssuer = jwtOptions.Issuer,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOptions.Secret)),
        ValidateIssuer = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidateAudience = false,
        ClockSkew = TimeSpan.Zero
      };
    });
		
    services.AddScoped<IJwtHandler, JwtHandler>();
    services.AddHttpContextAccessor();
    services.AddSingleton<ICurrentUserService, CurrentUserService>();
    services.AddScoped<IAccountService, AccountService>();

    return services;
  }
}