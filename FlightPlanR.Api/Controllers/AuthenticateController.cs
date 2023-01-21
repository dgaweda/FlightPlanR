using FlightPlanApi.Controllers.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Security.Authentication;
using Security.Services.Authenticate;

namespace FlightPlanApi.Controllers;

public class AuthenticateController : BaseController
{
	private readonly IAuthenticationService _authenticateService;

	public AuthenticateController(IAuthenticationService authenticateService)
	{
		_authenticateService = authenticateService;
	}

	[HttpPost("authenticate")]
	[AllowAnonymous]
	public async Task<IActionResult> Authenticate(AuthenticateRequest request)
	{
		var result = await _authenticateService.Authenticate(request);
		return Ok(result);
	}
}