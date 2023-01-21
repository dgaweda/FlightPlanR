using FlightPlanApi.Common.Authentication;
using FlightPlanApi.Models;
using FlightPlanR.Application.Extensions;
using FlightPlanR.DataAccess.Exceptions;
using FlightPlanR.DataAccess.Repository.User;

namespace FlightPlanR.Application.Services;

public class UserService : IUserService
{
	private readonly IUserRepository _userRepository;
	private readonly IJwtHandler _jwtHandler;

	public UserService(IUserRepository userRepository, IJwtHandler jwtHandler)
	{
		_userRepository = userRepository;
		_jwtHandler = jwtHandler;
	}
	
	public async Task<User> GetUserByUsername(string username)
	{
		var user = await _userRepository.FindByUsername(username).ThrowIfOperationFailed();
		return user;
	}

	public async Task<User> GetUserById(string userId)
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
	
	public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
	{
		var user = await _userRepository.FindByUsername(request.Username);
		if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
			throw new IdentityException("Username or password is incorrect.");

		return new AuthenticateResponse()
		{
			FirstName = user.FirstName,
			Id = user.Id,
			LastName = user.LastName,
			Token = await _jwtHandler.GenerateToken(user),
			Username = user.Username
		};
	}
}