using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace FlightPlanR.Domain.Common;

public abstract class Request
{
	[BsonElement("document_id")]
	[JsonIgnore]
	public string DocumentId { get; set; } = Guid.NewGuid().ToString("N");
}