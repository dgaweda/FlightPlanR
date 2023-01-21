using FlightPlanApi.Models;

namespace FlightPlanR.Application.Services;

public interface IUserService
{
	Task<User> GetUser(string userId);
	Task RemoveUser(string userId);
	Task EditUser(string userId, User user);
	Task AddUser(User user);
}