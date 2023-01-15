using System.Net;
using FlightPlanR.DataAccess.Exceptions;

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
        catch (NotFoundException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            await context.Response.WriteAsync(CreateMessage(ex));
        }
        catch (NotUpdatedException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NotModified;
            await context.Response.WriteAsync(CreateMessage(ex));
            await _next.Invoke(context);
        }
        catch (NoContentException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.NoContent;
            await context.Response.WriteAsync(CreateMessage(ex));
            await _next.Invoke(context);
        }
        catch (BadRequestException ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            await context.Response.WriteAsync(CreateMessage(ex));
        }
        catch (Exception ex)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            throw new Exception(CreateMessage(ex));
        }
    }

    private string CreateMessage(Exception ex) => $"{ex.Message}\n\n{ex.Source}\n\n{ex.StackTrace}";
}