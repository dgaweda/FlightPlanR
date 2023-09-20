using System.Net;
using System.Text.Json;
using FlightPlanR.Application.Common.Exceptions;

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
        catch (Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            
            switch (exception)
            {
                case IdentityException:
                    response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                case NotFoundException:
                    response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case BadRequestException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    break;
                case NotUpdatedException or NoContentException:
                    response.StatusCode = (int)HttpStatusCode.NotModified;
                    break;
                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }
            
            await response.WriteAsync(SerializeMessage(exception));
            Console.WriteLine(CreateMessage(exception));
        }
    }

    private string CreateMessage(Exception ex) => $"{ex.Message}\n{ex.Source}\n{ex.StackTrace}";

    private string SerializeMessage(Exception ex)
    {
        return JsonSerializer.Serialize(new { message = ex.Message });
    }
}