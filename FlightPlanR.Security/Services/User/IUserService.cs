using FlightPlanApi.Common.Authentication;
using FlightPlanApi.Models;

namespace FlightPlanR.Application.Services;

public interface IUserService
{
	Task<AuthenticateResponse> Authenticate(AuthenticateRequest request);
	Task<User> GetUserById(string userId);
	Task<User> GetUserByUsername(string userId);
	Task RemoveUser(string userId);
	Task EditUser(string userId, User user);
	Task AddUser(User user);
	
}