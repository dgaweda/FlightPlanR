using AutoMapper;
using FlightPlanR.Application.Common.Exceptions;
using FlightPlanR.Application.Common.Extensions;
using FlightPlanR.Application.Common.Interfaces;
using FlightPlanR.Application.Common.Security.Authentication;
using FlightPlanR.Application.Services.Account.DTO;
using FlightPlanR.Application.Services.Account.Request;

namespace FlightPlanR.Application.Services.Account;

public class AccountService : IAccountService
{
	private readonly IUserRepository _userRepository;
	private readonly IJwtHandler _jwtHandler;
	private readonly IMapper _mapper;

	public AccountService(IUserRepository userRepository, IJwtHandler jwtHandler, IMapper mapper)
	{
		_userRepository = userRepository;
		_jwtHandler = jwtHandler;
		_mapper = mapper;
	}

	public async Task<AuthenticateDto> Authenticate(AuthenticateRequest request)
	{
		var user = await _userRepository.FindByUsername(request.Username).ThrowLoginFailed();
		
		if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
			throw new IdentityException("Username or password is incorrect");

		return new AuthenticateDto()
		{
			FirstName = user.FirstName,
			UserId = user.Id,
			LastName = user.LastName,
			Token = await _jwtHandler.GenerateToken(user),
			UserName = user.Username
		};
	}

	public async Task<string> Register(RegisterUserRequest userData)
	{
		var user = await _userRepository.FindByUsername(userData.Username);
		if (user is not null)
			throw new BadRequestException("User already exists.");

		userData.Password = BCrypt.Net.BCrypt.HashPassword(userData.Password);
		var result = _mapper.Map<Domain.Entities.User>(userData);
		await _userRepository.InsertAsync(result).ThrowIfOperationFailed();

		return result.DocumentId;
	}

	public async Task<Domain.Entities.User> GetById(string id)
	{
		var result = await _userRepository.FindByIdAsync(id)
			.ThrowIfOperationFailed();
		return result;
	}
}