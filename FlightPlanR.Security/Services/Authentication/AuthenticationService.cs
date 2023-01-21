using FlightPlanApi.Common.Authentication;

namespace FlightPlanR.Security.Services;

public interface IAuthenticationService
{
	Task<string> Authenticate(AuthenticateRequest request);
	Task LogOut();
}