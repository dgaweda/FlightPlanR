using System.Text;
using FlightPlanR.Application.Common.Security.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace FlightPlanR.Application.Common.Security;

public static class ConfigureAuthentication
{
	private static readonly string JwtSection = "Jwt";
	public static IServiceCollection AddJSONWebTokenAuthentication(this IServiceCollection services, IConfiguration configuration)
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

		return services;
	}
}