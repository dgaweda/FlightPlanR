using MongoDB.Bson.Serialization.Attributes;

namespace FlightPlanR.Application.Services.Dictionary.Request;

public record AddCountryDictionaryRequest
{
	[BsonElement("id")]
	public string? Id { get; set; } = Guid.NewGuid().ToString("N");
	
	[BsonElement("country_id")] 
	public int CountryId { get; set; }
	
	[BsonElement("country_format")]
	public string Discriminator { get; set; }

	[BsonElement("country")]
	public string Country { get; set; }
	
	[BsonElement("value")]
	public string Value { get; set; }
}