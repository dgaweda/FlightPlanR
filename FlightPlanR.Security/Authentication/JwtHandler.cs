using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FlightPlanApi.Common.Exceptions;
using FlightPlanR.DataAccess.Entity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Security.Authentication;

public class JwtHandler : IJwtHandler
{
	private readonly JwtOptions _jwtOptions;
	private readonly TokenValidationParameters _tokenValidationParameters;
	public JwtHandler(JwtOptions jwtOptions, IOptionsMonitor<JwtBearerOptions> jwtBearerOptions)
	{
		_jwtOptions = jwtOptions;
		_tokenValidationParameters = jwtBearerOptions.Get(JwtBearerDefaults.AuthenticationScheme).TokenValidationParameters;
	}
	
	public Task<string> GenerateToken(User user)
	{
		var tokenHandler = new JwtSecurityTokenHandler();
		var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
		var tokenDescription = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(new[]
			{
				new Claim(JwtRegisteredClaimNames.Jti, user.DocumentId),
				new Claim(JwtRegisteredClaimNames.Sub, user.Username),
				new Claim("firstname", user.FirstName),
				new Claim("lastname", user.LastName),
				new Claim(JwtRegisteredClaimNames.Iss, _jwtOptions.Issuer)
			}),
			Expires = DateTime.UtcNow.AddHours(1),
			SigningCredentials =
				new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
		};
		var token = tokenHandler.CreateToken(tokenDescription);
		return Task.FromResult(tokenHandler.WriteToken(token));
	}

	public Task<string?> ValidateToken(string token)
	{
		if (token is null)
			return Task.FromResult<string>(null);

		var tokenHandler = new JwtSecurityTokenHandler();
		try
		{
			tokenHandler.ValidateToken(token, _tokenValidationParameters, out var validatedToken);
			
			var userId = ((JwtSecurityToken)validatedToken).Claims.First(claim => claim.Type == JwtRegisteredClaimNames.Jti).Value;
			return Task.FromResult(userId);
		}
		catch
		{
			return Task.FromResult<string>(null);
		}
	}
}