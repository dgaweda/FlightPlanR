using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlightPlanR.DataAccess.Entity.Base;

public abstract class BaseEntity
{
    [BsonId]
    public ObjectId ObjectId { get; set; }

    [BsonElement("id")] 
    public string? Id { get; set; }
}