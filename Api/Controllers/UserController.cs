using FlightPlanApi.Controllers.Base;
using FlightPlanR.Application.Services.User;
using FlightPlanR.Application.Services.User.Request;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanApi.Controllers;

public class UserController : BaseController
{
	private readonly IUserService _userService;
	
	public UserController(IUserService userService)
	{
		_userService = userService;
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetUserById(string id)
	{
		return Ok(await _userService.GetUserById(id));
	}
	
	[HttpGet]
	public async Task<IActionResult> GetUserByUsername(string username)
	{
		return Ok(await _userService.GetUserByUsername(username));
	}
	
	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateUser(string id, UpdateUserRequest request)
	{
		return Ok(await _userService.EditUser(id, request));
	}
	
	[HttpDelete("{id}")] 
	public async Task<IActionResult> RemoveUser(string id)
	{ 
		await _userService.RemoveUser(id);
		return Ok();
	}
}