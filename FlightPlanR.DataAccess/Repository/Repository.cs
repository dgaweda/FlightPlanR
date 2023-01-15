using FlightPlanApi.Common;
using MongoDB.Bson;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;

namespace FlightPlanR.DataAccess.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : new()
{
    private string CollectionName { get; }

    private readonly IMongoConfiguration _configuration;

    protected Repository(IMongoConfiguration configuration, string collectionName)
    {
        _configuration = configuration;
        CollectionName = collectionName;
    }
    protected IMongoCollection<BsonDocument> GetCollection(string databaseName, string collectionName)
    {
        var client = new MongoClient();
        var database = client.GetDatabase(databaseName);
        return database.GetCollection<BsonDocument>(collectionName);
    }
    
    [Obsolete("Unused ?")]
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

    public virtual async Task<List<TEntity>> FindAllAsync()
    {
        var documents = await GetCollection(_configuration.Name , CollectionName)
            .Find(_ => true).ToListAsync();

        var flightPlans = new List<TEntity>();
        if (documents is null) return flightPlans;
        foreach (var bsonDocument in documents)
        {
            var converted = bsonDocument.ToJson();
            var convertedObject = JObject.Parse(converted).ToObject<TEntity>();
            flightPlans.Add(convertedObject);
        }

        return flightPlans;
    }

    public virtual async Task<TEntity> FindByIdAsync(string id)
    {
        var collection = GetCollection(_configuration.Name, CollectionName);
        var flightPlanCursor = await collection
            .FindAsync(Builders<BsonDocument>.Filter.Eq("id", id));
        var document = await flightPlanCursor.FirstOrDefaultAsync();

        var flightPlan = JObject.Parse(document.ToJson()).ToObject<TEntity>();
        return flightPlan ?? new TEntity();
    }

    public virtual async Task InsertAsync(TEntity flightPlan)
    {
        await GetCollection(_configuration.Name, CollectionName)
            .InsertOneAsync(flightPlan.ToJson().ToBsonDocument());
    }

    public virtual async Task UpdateAsync(string id, TEntity flightPlan)
    {
        await RemoveAsync(id);
        await InsertAsync(flightPlan);
    }

    public virtual async Task RemoveAsync(string id)
    {
        await GetCollection(_configuration.Name, CollectionName)
            .DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("id", id));
        
    }
}