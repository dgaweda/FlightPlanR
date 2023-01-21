﻿using System.IdentityModel.Tokens.Jwt;
using FlightPlanR.DataAccess.Entity;
using Microsoft.AspNetCore.Http;

namespace Security.Services.CurrentUser;

public class CurrentUserService : ICurrentUserService
{
	private readonly IHttpContextAccessor _context;
	
	public CurrentUserService(IHttpContextAccessor context)
	{
		_context = context;
	}
	
	public Task<User> GetCurrentUser()
	{
		var user = new User()
		{
			Id = _context.HttpContext?.User.FindFirst(JwtRegisteredClaimNames.Jti)?.Value,
			Username = _context.HttpContext?.User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value,
			FirstName = _context.HttpContext?.User.FindFirst("firstname")?.Value,
			LastName = _context.HttpContext?.User.FindFirst("lastname")?.Value
		};
		return Task.FromResult(user);
	}
}