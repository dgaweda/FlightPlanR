using FlightPlanApi.Models;
using FlightPlanR.Application.Extensions;
using FlightPlanR.DataAccess.Exceptions;
using FlightPlanR.DataAccess.Repository.User;

namespace FlightPlanR.Application.Services;

public class UserService : IUserService
{
	private readonly IUserRepository _userRepository;

	public UserService(IUserRepository userRepository)
	{
		_userRepository = userRepository;
	}

	public async Task<User> GetUser(string userId)
	{
		var user = await _userRepository.FindByIdAsync(userId).ThrowIfOperationFailed();
		return user;
	}

	public async Task RemoveUser(string userId)
	{
		await _userRepository.RemoveAsync(userId).ThrowIfOperationFailed();
	}

	public async Task EditUser(string userId, User user)
	{

		await _userRepository.UpdateAsync(userId, user).ThrowIfOperationFailed();
	}
	
	public async Task AddUser(User userData)
	{
		var user = await _userRepository.FindByUsername(userData.Username);
		if (user is not null)
			throw new IdentityException("User already exists.");

		userData.Password = BCrypt.Net.BCrypt.HashPassword(userData.Password);
		
		await _userRepository.InsertAsync(userData).ThrowIfOperationFailed();
	}
}