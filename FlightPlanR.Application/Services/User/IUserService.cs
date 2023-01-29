using FlightPlanR.Application.Services.User.Request;

namespace FlightPlanR.Application.Services.User;

public interface IUserService
{
	Task<DataAccess.Entity.User> GetUserById(string userId);
	Task<DataAccess.Entity.User> GetUserByUsername(string userId);
	Task RemoveUser(string userId);
	Task<string> EditUser(string userId, UpdateUserRequest user);
	Task<string> AddUser(AddUserRequest user);
	
}