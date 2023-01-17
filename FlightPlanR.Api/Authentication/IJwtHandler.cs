namespace FlightPlanApi.Common.Authentication;

public interface IJwtHandler
{
	Task<string> GenerateToken(string userId);
	Task<string> ValidateToken(string token);
}