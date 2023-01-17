using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FlightPlanR.DataAccess.Exceptions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FlightPlanApi.Common.Authentication;

public class JwtHandler : IJwtHandler
{
	private readonly JwtOptions _jwtOptions;
	public JwtHandler(IOptions<JwtOptions> jwtOptions)
	{
		_jwtOptions = jwtOptions.Value;
	}
	
	public Task<string> GenerateToken(string userId)
	{
		var tokenHandler = new JwtSecurityTokenHandler();
		var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
		var tokenDescription = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(new[]
			{
				new Claim(JwtRegisteredClaimNames.UniqueName, userId)
			}),
			Expires = DateTime.UtcNow.AddHours(1),
			SigningCredentials =
				new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
		};
		var token = tokenHandler.CreateToken(tokenDescription);
		return Task.FromResult(tokenHandler.WriteToken(token));
	}

	public Task<string> ValidateToken(string token)
	{
		if (token is null)
			throw new IdentityException();

		var tokenHandler = new JwtSecurityTokenHandler();
		var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
		try
		{
			tokenHandler.ValidateToken(token, new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = new SymmetricSecurityKey(key),
				ValidateIssuer = false,
				ClockSkew = TimeSpan.Zero
			}, out var validatedToken);

			var jwtToken = (JwtSecurityToken)validatedToken;
			var userId = jwtToken.Claims.First(claim => claim.Type == JwtRegisteredClaimNames.UniqueName).Value;
			return Task.FromResult(userId);
		}
		catch
		{
			throw new IdentityException();
		}
	}
}