using System.Reflection;
using FlightPlanApi.Common;
using FlightPlanApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;

namespace FlightPlanR.DataAccess.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity, new()
{
    private string CollectionName { get; }

    private readonly MongoConfiguration _configuration;

    protected Repository(IOptions<MongoConfiguration> configuration, string collectionName)
    {
        _configuration = configuration.Value;
        CollectionName = collectionName;
    }
    protected IMongoCollection<BsonDocument> GetCollection(string collectionName)
    {
        var client = new MongoClient();
        var database = client.GetDatabase(_configuration.Name);
        return database.GetCollection<BsonDocument>(collectionName);
    }

    public virtual async Task<List<TEntity>> FindAllAsync()
    {
        var documents = await GetCollection(CollectionName)
            .Find(_ => true).ToListAsync();

        var flightPlans = new List<TEntity>();
        
        if (documents is null) return flightPlans;
        
        flightPlans.AddRange(documents.Select(bsonDocument => BsonSerializer.Deserialize<TEntity>(bsonDocument)));

        return flightPlans;
    }

    public virtual async Task<TEntity?> FindByIdAsync(string id)
    {
        var collection = GetCollection(CollectionName);
        var flightPlanCursor = await collection
            .FindAsync(Builders<BsonDocument>.Filter.Eq("id", id));
        var document = await flightPlanCursor.FirstOrDefaultAsync();
        if (document is null) return null;

        var flightPlan = BsonSerializer.Deserialize<TEntity>(document);
        return flightPlan;
    }

    public virtual async Task<bool> InsertAsync(TEntity entity)
    {
        var collection = GetCollection(CollectionName);
        await collection.InsertOneAsync(entity.ToJson().ToBsonDocument());

        return collection.Find(Builders<BsonDocument>.Filter.AnyEq("id", entity.Id)) is null;
    }

    public virtual async Task<UpdateResult> UpdateAsync(TEntity entity)
    {
        var collection = GetCollection(CollectionName);
        var documentToUpdate = Builders<BsonDocument>.Filter.Eq("id", entity.Id);

        if (documentToUpdate is null) return null;

        UpdateDefinition<BsonDocument> updatedDocument = null;
        
        var properties = entity.GetType()
            .GetProperties()
            .ToList();

        foreach (var property in properties)
        {
            var propertyAttribute = property.GetCustomAttribute<BsonElementAttribute>();
            var propertyBsonName = propertyAttribute is null ? property.Name : propertyAttribute.ElementName;
            updatedDocument = updatedDocument.Set(propertyBsonName, property.GetValue(entity));
        }
            // .ForEach(property =>
            // {
            //     var propertyBsonName = property.GetCustomAttribute<BsonElementAttribute>().ElementName;
            //     updatedDocument = updatedDocument.Set(propertyBsonName, property.GetValue(property));
            // });

        return await collection.UpdateOneAsync(documentToUpdate, updatedDocument);
    }

    public virtual async Task<DeleteResult> RemoveAsync(string id)
    {
        return await GetCollection(CollectionName)
            .DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("id", id));
    }
}