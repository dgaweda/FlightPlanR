namespace FlightPlanApi.Middleware;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (BadHttpRequestException ex)
        {
            throw new BadHttpRequestException("Bad Request");
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
}