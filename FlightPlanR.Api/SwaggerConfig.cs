using System.Reflection;
using Microsoft.OpenApi.Models;

namespace FlightPlanApi;

public static class SwaggerConfig
{
	public static IServiceCollection AddSwaggerConfig(this IServiceCollection services)
	{
		services.AddSwaggerGen(options =>
		{
			options.SwaggerDoc("flightplanr", new OpenApiInfo
			{
				Title = "Flight Plan API",
				Version = "v3",
				Description = "FlightPlanR Web API with NO-SQL DB"
			});
    
			options.AddSecurityDefinition("jwt", new OpenApiSecurityScheme
			{
				Name = "Authorization",
				Type = SecuritySchemeType.Http,
				Scheme = "Bearer",
				In = ParameterLocation.Header,
				Description = "Json Web Token Bearer Authorization"
			});
    
			options.AddSecurityRequirement(new OpenApiSecurityRequirement
			{
				{
					new OpenApiSecurityScheme
					{
						Reference = new OpenApiReference
						{
							Type = ReferenceType.SecurityScheme,
							Id = "jwt"
						}
					},
					new string[] { }
				}
        
			});
			options.EnableAnnotations();
			var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
			options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
		});
		return services;
	}
}