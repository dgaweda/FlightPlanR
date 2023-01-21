using FlightPlanApi.Common.Authentication;
using FlightPlanR.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanApi.Controllers;

public class UserController : BaseController
{
	private readonly IUserService _userService;
	
	public UserController(IUserService userService)
	{
		_userService = userService;
	}
	
	[HttpPost("/authenticate")]
	public async Task<IActionResult> Authenticate(AuthenticateRequest request)
	{
		var result = await _userService.Authenticate(request);
		return Ok(result);
	}
	
	[HttpPost]
	public async Task<IActionResult> AddUser(AddUserRequest request)
	{
		var result = await _userService.AddUser(request);
		return Ok(result);
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
	public async Task<IActionResult> UpdateUser(string id)
	{ 
		await _userService.RemoveUser(id);
		return Ok();
	}
}