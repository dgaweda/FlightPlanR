using FlightPlanApi.Controllers.Base;
using FlightPlanR.Application.Services;
using FlightPlanR.Application.Services.User;
using FlightPlanR.Application.Services.User.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanApi.Controllers;

public class UserController : BaseController
{
	private readonly IUserService _userService;
	
	public UserController(IUserService userService)
	{
		_userService = userService;
	}

	[HttpPost("register")]
	[AllowAnonymous]
	public async Task<IActionResult> AddUser(AddUserRequest request)
	{
		await _userService.AddUser(request);
		return Ok();
	}
	
	[HttpGet("{id}")]
	public async Task<IActionResult> GetUserById(string id)
	{
		var result = await _userService.GetUserByUsername(id);
		return Ok(result);
	}
	
	[HttpGet]
	public async Task<IActionResult> GetUserByUsername(string username)
	{
		var result = await _userService.GetUserByUsername(username);
		return Ok(result);
	}
	
	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateUser(string id, UpdateUserRequest request)
	{
		await _userService.EditUser(id, request);
		return Ok();
	}
	
	[HttpDelete("{id}")] 
	public async Task<IActionResult> RemoveUser(string id)
	{ 
		await _userService.RemoveUser(id);
		return Ok();
	}
}