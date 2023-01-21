using FlightPlanApi.Common.Authentication;
using FlightPlanApi.Models;
using FlightPlanR.Application.Extensions;
using FlightPlanR.DataAccess.Exceptions;
using FlightPlanR.DataAccess.Repository.User;

namespace FlightPlanR.Security.Services;

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