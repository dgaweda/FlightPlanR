using FlightPlanApi.Common.Exceptions;
using FlightPlanApi.Common.Extensions;
using FlightPlanR.Application.Services.User.Request;
using FlightPlanR.DataAccess.Repositories.User;

namespace FlightPlanR.Application.Services.User;

public class UserService : IUserService
{
	private readonly IUserRepository _userRepository;

	public UserService(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}
	
	public async Task<DataAccess.Entity.User> GetUserByUsername(string username)
	{
		var user = await _userRepository.FindByUsername(username).ThrowIfOperationFailed();
		return user;
	}

	public async Task<DataAccess.Entity.User> GetUserById(string userId)
	{
		var user = await _userRepository.FindByIdAsync(userId).ThrowIfOperationFailed();
		return user;
	}

	public async Task RemoveUser(string userId)
	{
		await _userRepository.RemoveAsync(userId).ThrowIfOperationFailed();
	}

	public async Task EditUser(string userId, UpdateUserRequest user)
	{

		await _userRepository.UpdateAsync(userId, user).ThrowIfOperationFailed();
	}
	
	public async Task AddUser(AddUserRequest userData)
	{
		var user = await _userRepository.FindByUsername(userData.Username);
		if (user is not null)
			throw new IdentityException("User already exists.");

		userData.Password = BCrypt.Net.BCrypt.HashPassword(userData.Password);
		
		await _userRepository.InsertAsync(userData).ThrowIfOperationFailed();
	}
}