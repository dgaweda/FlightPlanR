using FlightPlanR.DataAccess.Entity.Base;
using MongoDB.Bson.Serialization.Attributes;

namespace FlightPlanR.DataAccess.Entity.Dictionary.Countries;

[BsonKnownTypes(typeof(CountryA2), typeof(CountryA3), typeof(CountryEN), typeof(CountrySE))]
[BsonDiscriminator(RootClass = true)]
public class BaseCountry : BaseEntity
{
	[BsonElement("country_format")]
	public string CountryFormat { get; set; }
	
}