using FlightPlanR.DataAccess.Entity;

namespace Security.Authentication;

public interface IJwtHandler
{
	Task<string> GenerateToken(User user);
	Task<string> ValidateToken(string token);
}