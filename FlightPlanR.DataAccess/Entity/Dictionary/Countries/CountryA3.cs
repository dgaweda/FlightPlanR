using MongoDB.Bson.Serialization.Attributes;

namespace FlightPlanR.DataAccess.Entity.Dictionary.Countries;

public class CountryA3 : BaseCountry
{
	[BsonElement("country")]
	public string Country { get; set; }
	
	[BsonElement("value")]
	public string Value { get; set; }
	
	[BsonElement("country_id")] 
	public int CountryId { get; set; }
}