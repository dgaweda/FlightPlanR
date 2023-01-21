using FlightPlanApi.Models;

namespace FlightPlanR.Application.Services;

public interface IUserService
{
	Task<User> GetUser(string userId);
	Task AddUser(User user);
	Task RemoveUser(string userId);
	Task EditUser(string userId, User user);
}