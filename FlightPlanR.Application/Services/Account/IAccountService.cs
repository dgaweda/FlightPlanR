using FlightPlanR.Application.Services.Account.Request;
using FlightPlanR.Application.Services.Account.Response;

namespace FlightPlanR.Application.Services.Account;

public interface IAccountService
{
	Task<AuthenticateDto> Authenticate(AuthenticateRequest request);
	Task<string> Register(RegisterUserRequest user);
	Task<Domain.Entities.User> GetById(string id);
}