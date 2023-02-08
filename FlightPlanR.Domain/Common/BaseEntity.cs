using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlightPlanR.Domain.Common;

public abstract class BaseEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
   
    [BsonElement("document_id")]
    public string DocumentId { get; set; }
}