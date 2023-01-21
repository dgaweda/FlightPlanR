using FlightPlanApi.Common.Authentication;
using FlightPlanApi.Models;

namespace FlightPlanR.Security.Services;

public interface IAuthenticationService
{
	Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
}