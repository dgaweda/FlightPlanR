using FlightPlanApi.Controllers.Base;
using FlightPlanR.Application.Services.Account;
using FlightPlanR.Application.Services.Account.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanApi.Controllers;

[AllowAnonymous]
public class AuthenticateController : BaseController
{
	private readonly IAccountService _accountService;

	public AuthenticateController(IAccountService accountService)
	{
		_accountService = accountService;
	}

	[HttpPost("authenticate")]
	public async Task<IActionResult> Authenticate(AuthenticateRequest request)
	{
		var result = await _accountService.Authenticate(request);
		return Ok(result);
	}
	
	[HttpPost("register")]
	public async Task<IActionResult> Register(RegisterUserRequest request)
	{
		return Ok(await _accountService.Register(request));
	}
}