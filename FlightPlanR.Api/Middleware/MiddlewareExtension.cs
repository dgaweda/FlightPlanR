namespace FlightPlanApi.Middleware;

public static class MiddlewareExtension
{
    public static IApplicationBuilder UseMiddlewares(this IApplicationBuilder builder) =>
        builder.UseMiddleware<ErrorHandlerMiddleware>();
}