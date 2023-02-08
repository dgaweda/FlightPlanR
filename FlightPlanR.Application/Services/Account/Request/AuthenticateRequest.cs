using MongoDB.Bson.Serialization.Attributes;

namespace FlightPlanR.Application.Services.Account.Request;

public record AuthenticateRequest
{
	[BsonElement("username")]
	public string Username { get; set; }
	
	[BsonElement("password")]
	public string Password { get; set; }
}