using FlightPlanApi.Common;
using MongoDB.Bson;

namespace FlightPlanApi.Models;

public class BaseDocument<T> where T : new()
{
    public T FromBsonToModel(BsonDocument? document)
    {
        var model = new T();
        var propertyNames = model.GetJsonPropertyNames();

        foreach (var bsonElement in document)
        {
            var property = model.GetType().GetProperty(propertyNames[bsonElement.Name]);
            model.SetPropertyValue(bsonElement.Value, property);
        }

        return model;
    }
}