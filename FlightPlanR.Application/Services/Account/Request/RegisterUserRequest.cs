using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace FlightPlanR.Application.Services.Account.Request;

public record RegisterUserRequest
{
	[BsonElement("document_id")]
	[JsonIgnore]
	public string DocumentId { get; set; } = Guid.NewGuid().ToString("N");
	
	[BsonElement("firstname")]
	public string FirstName { get; set; }
	[BsonElement("lastname")]
	public string LastName { get; set; }
	[BsonElement("username")]
	public string Username { get; set; }
	[BsonElement("password")]
	public string Password { get; set; }

	[BsonElement("is_admin")]
	[JsonIgnore]
	public bool IsAdmin { get; set; } = false;
}