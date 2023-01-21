using FlightPlanR.DataAccess.Entity;
using Security.Authentication;

namespace Security.Services.Authenticate;

public interface IAuthenticationService
{
	Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
	Task<User> GetById(string id);
}