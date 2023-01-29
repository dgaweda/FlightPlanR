using AutoMapper;
using FlightPlanApi.Common.Exceptions;
using FlightPlanApi.Common.Extensions;
using FlightPlanR.Application.Services.User.Request;
using FlightPlanR.DataAccess.Repositories.User;

namespace FlightPlanR.Application.Services.User;

public class UserService : IUserService
{
	private readonly IUserRepository _userRepository;
	private readonly IMapper _mapper;

	public UserService(IUserRepository userRepository, IMapper mapper)
	{
		_userRepository = userRepository;
		_mapper = mapper;
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

	public async Task<string> EditUser(string userId, UpdateUserRequest user)
	{
		var result = _mapper.Map<DataAccess.Entity.User>(user);
		await _userRepository.UpdateAsync(userId, result).ThrowIfOperationFailed();

		return result.DocumentId;
	}
	
	public async Task<string> AddUser(AddUserRequest userData)
	{
		var user = await _userRepository.FindByUsername(userData.Username);
		if (user is not null)
			throw new BadRequestException("User already exists.");

		userData.Password = BCrypt.Net.BCrypt.HashPassword(userData.Password);
		var result = _mapper.Map<DataAccess.Entity.User>(userData);
		await _userRepository.InsertAsync(result).ThrowIfOperationFailed();

		return result.DocumentId;
	}
}