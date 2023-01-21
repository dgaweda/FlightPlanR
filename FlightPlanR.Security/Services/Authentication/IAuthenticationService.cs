

using FlightPlanApi.Common.Authentication;

namespace FlightPlanR.Security.Services;

public class AuthenticationService : IAuthenticationService
{
	public async Task<string> Authenticate(AuthenticateRequest request)
	{
		throw new NotImplementedException();
	}

	public async Task LogOut()
	{
		throw new NotImplementedException();
	}
}