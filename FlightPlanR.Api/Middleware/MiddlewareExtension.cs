using Security.Middleware;

namespace FlightPlanApi.Middleware;

public static class MiddlewareExtension
{
	public static IApplicationBuilder UseCustomeMiddlewares(this IApplicationBuilder builder)
	{
		builder.UseMiddleware<ErrorHandlerMiddleware>();
		builder.UseMiddleware<JwtMiddleware>();
		return builder;
	}

}