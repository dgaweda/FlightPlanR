using System.Text.Json.Serialization;
using FlightPlanApi.Common;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlightPlanR.DataAccess.Repository;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : new()
{
    protected IMongoCollection<BsonDocument> GetCollection(string databaseName, string collectionName)
    {
        var client = new MongoClient();
        var database = client.GetDatabase(databaseName);
        return database.GetCollection<BsonDocument>(collectionName);
    }
    
    protected TEntity? ConvertFromBsonToEntity(BsonDocument? document)
    {
        var model = new TEntity();
        var jsonPropertyNames = model.GetEntityJsonPropertyNames();

        if (document is null) return default;
        
        foreach (var bsonElement in document)
        {
            var property = model.GetType().GetProperty(jsonPropertyNames[bsonElement.Name]);
            model.SetPropertyValue(bsonElement.Value, property);
        }

        return model;
    }

    public abstract Task<List<TEntity>> FindAllAsync();
    public abstract Task<TEntity> FindByIdAsync(string flightPlanId);
    public abstract Task InsertAsync(TEntity flightPlan);
    public abstract Task UpdateAsync(string flightPlanId, TEntity flightPlan);
    public abstract Task RemoveAsync(string flightPlanId);
}