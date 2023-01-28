using MongoDB.Bson.Serialization.Attributes;

namespace FlightPlanR.Application.Services.User.Request;

public class AddUserRequest : FlightPlanApi.Common.Request
{

	[BsonElement("firstname")]
	public string FirstName { get; set; }
	[BsonElement("lastname")]
	public string LastName { get; set; }
	[BsonElement("username")]
	public string Username { get; set; }
	[BsonElement("password")]
	public string Password { get; set; }
}