﻿namespace FlightPlanR.Application.Services.Account.DTO;

public class AuthenticateDto
{
	public string UserId { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Username { get; set; }
	public string Token { get; set; }
}