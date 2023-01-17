using FlightPlanApi.Common.Authentication;
using FlightPlanR.Application.Services;

namespace FlightPlanApi.Middleware;

public class JwtMiddleware
{
	private readonly RequestDelegate _next;

	public JwtMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context, IUserService userService, IJwtHandler jwtHandler)
	{
		throw new NotImplementedException();
	}
}