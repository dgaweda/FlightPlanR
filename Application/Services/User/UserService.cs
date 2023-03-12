using AutoMapper;
using FlightPlanR.Application.Common.Extensions;
using FlightPlanR.Application.Common.Interfaces;
using FlightPlanR.Application.Services.User.Request;

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
	
	public async Task<Domain.Entities.User> GetUserByUsername(string username)
	{
		var user = await _userRepository.FindByUsername(username).ThrowIfOperationFailed();
		return user;
	}

	public async Task<Domain.Entities.User> GetUserById(string userId)
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
		var result = _mapper.Map<Domain.Entities.User>(user);
		await _userRepository.UpdateAsync(userId, result).ThrowIfOperationFailed();

		return result.DocumentId;
	}
}