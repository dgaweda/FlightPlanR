using FlightPlanR.Domain.Entities;

namespace FlightPlanR.Application.Common.Security.Authentication;

public interface IJwtHandler
{
	Task<string> GenerateToken(User user);
	Task<string?> ValidateToken(string token);
}