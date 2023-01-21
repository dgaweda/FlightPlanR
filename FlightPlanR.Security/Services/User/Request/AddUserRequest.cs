﻿namespace FlightPlanApi.Common.Authentication;

public record AddUserRequest
{
	public string Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string Username { get; set; }
	public string Password { get; set; }
}