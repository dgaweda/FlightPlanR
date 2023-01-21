using FlightPlanApi.Common.Authentication;
using FlightPlanR.Security.Services;
using Microsoft.AspNetCore.Http;

namespace FlightPlanApi.Middleware;

public class JwtMiddleware
{
	private readonly RequestDelegate _next;

	public JwtMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context, IAuthenticationService authenticationService, IJwtHandler jwtHandler)
	{
		throw new NotImplementedException();
	}
}