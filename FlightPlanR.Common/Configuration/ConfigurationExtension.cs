using Microsoft.Extensions.Configuration;

namespace FlightPlanApi.Configuration;

public static class ConfigurationExtension
{
	public static TOptions GetOptions<TOptions>(this IConfiguration configuration, string section) where TOptions : new()
	{
		var options = new TOptions();
		configuration.GetSection(section).Bind(options);
		return options;
	}
}