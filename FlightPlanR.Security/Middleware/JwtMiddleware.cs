using FlightPlanApi.Common.Authentication;
using FlightPlanR.Application.Extensions;
using FlightPlanR.Application.Services;
using FlightPlanR.Security.Services;
using Microsoft.AspNetCore.Http;

namespace FlightPlanApi.Middleware;

public class JwtMiddleware
{
	private readonly RequestDelegate _next;
	private static readonly string AuthHeader = "Authorization";

	public JwtMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context, IUserService userService, IJwtHandler jwtHandler)
	{
		var token = context.Request.Headers[AuthHeader].FirstOrDefault().Split(" ").Last();
		var userId = await jwtHandler.ValidateToken(token);
		if (userId is not null)
		{
			context.Items["User"] = await userService.GetUserByUsername(userId);
		}

		await _next.Invoke(context);
	}
}