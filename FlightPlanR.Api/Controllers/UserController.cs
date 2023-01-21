using FlightPlanR.Application.Services;
using FlightPlanR.Security.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanApi.Controllers;

public class UserController : BaseController
{
	private readonly IUserService _userService;
	private readonly IAuthenticationService _authenticationService;
	
	public UserController(IUserService userService, IAuthenticationService authenticationService)
	{
		_userService = userService;
		_authenticationService = authenticationService;
	}
	public async Task<IActionResult> Authenticate(string username, string password)
	{
		throw new NotImplementedException();
	}
}