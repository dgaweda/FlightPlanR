using FlightPlanR.Application.Services.User.Request;

namespace FlightPlanR.Application.Services.User;

public interface IUserService
{
	Task<Domain.Entities.User> GetUserById(string userId);
	Task<Domain.Entities.User> GetUserByUsername(string userId);
	Task RemoveUser(string userId);
	Task<string> EditUser(string userId, UpdateUserRequest user);
}