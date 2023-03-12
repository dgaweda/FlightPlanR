using FlightPlanR.Application.Common.Security.Authentication;
using FlightPlanR.Application.Services.Account;
using Microsoft.AspNetCore.Http;

namespace FlightPlanR.Application.Common.Security.Middleware;

public class JwtMiddleware
{
	private readonly RequestDelegate _next;
	private const string AuthHeader = "Authorization";

	public JwtMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context, IAccountService accountService, IJwtHandler jwtHandler)
	{
		var token = context.Request.Headers[AuthHeader].FirstOrDefault()?.Split(" ").Last();
		var userId = await jwtHandler.ValidateToken(token);
		if (userId is not null)
		{
			context.Items["User"] = await accountService.GetById(userId);
		}

		await _next.Invoke(context);
	}
}