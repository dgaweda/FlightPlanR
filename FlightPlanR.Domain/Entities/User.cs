using FlightPlanR.Domain.Common;
using FlightPlanR.Domain.Common.Attributes;
using MongoDB.Bson.Serialization.Attributes;

namespace FlightPlanR.Domain.Entities;

[MongoCollection("user")]
public class User : BaseEntity
{
	[BsonElement("firstname")]
	public string FirstName { get; set; }
	[BsonElement("lastname")]
	public string LastName { get; set; }
	[BsonElement("username")]
	public string Username { get; set; }
	[BsonElement("password")]
	public string Password { get; set; }
	
	[BsonElement("is_admin")]
	public bool IsAdmin { get; set; }
}