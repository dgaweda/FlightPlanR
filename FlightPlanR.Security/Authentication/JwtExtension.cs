using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Security.Authentication;

public static class JwtExtension
{
	private static readonly string JwtSection = "Jwt";

	public static IServiceCollection AddJwt(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddAuthentication(options =>
		{
			options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		}).AddJwtBearer();
		
		services.Configure<JwtOptions>(configuration.GetSection(JwtSection));
		services.AddScoped<IJwtHandler, JwtHandler>();
		return services;
	}
}