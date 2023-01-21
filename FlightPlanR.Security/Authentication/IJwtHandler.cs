using FlightPlanApi.Models;

namespace FlightPlanApi.Common.Authentication;

public interface IJwtHandler
{
	Task<string> GenerateToken(User user);
	Task<string> ValidateToken(string token);
}