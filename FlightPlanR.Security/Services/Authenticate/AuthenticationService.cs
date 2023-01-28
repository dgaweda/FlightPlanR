using FlightPlanApi.Common.Exceptions;
using FlightPlanApi.Common.Extensions;
using FlightPlanR.DataAccess.Entity;
using FlightPlanR.DataAccess.Repositories.User;
using Security.Authentication;

namespace Security.Services.Authenticate;

public class AuthenticationService : IAuthenticationService
{
	private readonly IUserRepository _userRepository;
	private readonly IJwtHandler _jwtHandler;

	public AuthenticationService(IUserRepository userRepository, IJwtHandler jwtHandler)
	{
		_userRepository = userRepository;
		_jwtHandler = jwtHandler;
	}

	public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest request)
	{
		var user = await _userRepository.FindByUsername(request.Username)
			.ThrowIfOperationFailed();
		if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
			throw new IdentityException("Username or password is incorrect");

		return new AuthenticateResponse()
		{
			FirstName = user.FirstName,
			UserId = user.Id,
			LastName = user.LastName,
			Token = await _jwtHandler.GenerateToken(user),
			Username = user.Username
		};
	}

	public async Task<User> GetById(string id)
	{
		var result = await _userRepository.FindByIdAsync(id)
			.ThrowIfOperationFailed();
		return result;
	}
}