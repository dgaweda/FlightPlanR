using System.Reflection;
using System.Text.Json.Serialization;
using MongoDB.Bson;

namespace FlightPlanApi.Common;

public static class ModelsExtension
{
    public static Dictionary<string, string> GetJsonPropertyNames<T>(this T model)
    {
        var propertiesDictionary = new Dictionary<string, string>();
        model?.GetType()
            .GetProperties()
            .ToList()
            .ForEach(property =>
            { 
                var jsonPropertyNameAttribute = property.GetCustomAttribute<JsonPropertyNameAttribute>();
                var jsonPropertyName = jsonPropertyNameAttribute is null ? property.Name : jsonPropertyNameAttribute.Name;
                propertiesDictionary.Add(jsonPropertyName, property.Name);
            });

        return propertiesDictionary;
    }
    
    public static void SetPropertyValue<T>(this T model, BsonValue bsonValue, PropertyInfo property)
    {
        switch(property.PropertyType)
        {
            case Type pType when pType == typeof(string): 
                property.SetValue(model, bsonValue.AsString);
                break;
            case Type pType when pType == typeof(int):
                property.SetValue(model, bsonValue.AsInt32);
                break;
            case Type pType when pType == typeof(DateTime):
                property.SetValue(model, bsonValue.AsBsonDateTime.ToLocalTime());
                break;
        };
    }
}