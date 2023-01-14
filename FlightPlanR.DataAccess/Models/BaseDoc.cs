using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using FlightPlanApi.Common;
using FlightPlanApi.Common.Enums;
using MongoDB.Bson;

namespace FlightPlanApi.Models;

public class BaseDocument<T> where T : new()
{
    protected T? FromBsonToModel(BsonDocument? document)
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