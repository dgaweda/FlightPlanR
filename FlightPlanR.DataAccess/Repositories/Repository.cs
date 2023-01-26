using FlightPlanApi.Common.Configuration;
using FlightPlanR.DataAccess.Entity.Base;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace FlightPlanR.DataAccess.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    private string CollectionName { get; }

    private readonly MongoConfiguration _configuration;

    public Repository(IOptions<MongoConfiguration> configuration, string collectionName)
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

        var entities = new List<TEntity>();
        
        if (documents is null) return entities;
        
        entities.AddRange(documents.Select(bsonDocument => BsonSerializer.Deserialize<TEntity>(bsonDocument)));

        return entities;
    }

    public virtual async Task<TEntity?> FindByIdAsync(string id)
    {
        var collection = GetCollection(CollectionName);
        var documentCursor = await collection
            .FindAsync(Builders<BsonDocument>.Filter.Eq("id", id));
        var document = await documentCursor.FirstOrDefaultAsync();
        
        if (document is null) return null;

        return BsonSerializer.Deserialize<TEntity>(document);
    }

    public virtual async Task<bool> InsertAsync<TRequest>(TRequest request)
    {
        var collection = GetCollection(CollectionName);
        var document = request.ToBsonDocument();
        await collection.InsertOneAsync(document);
    }

    public virtual async Task<UpdateResult> UpdateAsync<TRequest>(string id, TRequest request)
    {
        var collection = GetCollection(CollectionName);
        var documentToUpdate = Builders<BsonDocument>.Filter.Eq("id", id);

        if (documentToUpdate is null) return null;

        return await collection.UpdateOneAsync(documentToUpdate, new BsonDocument { { "$set", request.ToBsonDocument() } });
    }

    public virtual async Task<DeleteResult> RemoveAsync(string id)
    {
        return await GetCollection(CollectionName)
            .DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("id", id));
    }
}