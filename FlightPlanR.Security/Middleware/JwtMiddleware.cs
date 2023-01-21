using Microsoft.AspNetCore.Http;
using Security.Authentication;
using Security.Services.Authenticate;

namespace Security.Middleware;

public class JwtMiddleware
{
	private readonly RequestDelegate _next;
	private const string AuthHeader = "Authorization";

	public JwtMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context, IAuthenticationService authenticationService, IJwtHandler jwtHandler)
	{
		var token = context.Request.Headers[AuthHeader].FirstOrDefault().Split(" ").Last();
		var userId = await jwtHandler.ValidateToken(token);
		if (userId is not null)
		{
			context.Items["User"] = await authenticationService.GetById(userId);
		}

		await _next.Invoke(context);
	}
}