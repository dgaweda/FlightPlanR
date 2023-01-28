using System.Reflection;
using FlightPlanApi.Common.Attributes;
using FlightPlanApi.Common.Configuration;
using FlightPlanR.DataAccess.Entity.Base;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace FlightPlanR.DataAccess.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity.Base.Entity
{
    private readonly MongoConfiguration _configuration;
    private readonly string _collection;

    public Repository(IOptions<MongoConfiguration> configuration)
    {
        _configuration = configuration.Value;
        _collection = typeof(TEntity).GetType().GetCustomAttribute<MongoCollectionAttribute>()?.CollectionName;
    }
    protected IMongoCollection<BsonDocument> GetCollection()
    {
        var client = new MongoClient();
        var database = client.GetDatabase(_configuration.Name);
        return database.GetCollection<BsonDocument>(_collection);
    }

    public virtual async Task<List<TEntity>> FindAllAsync()
    {
        var documents = await GetCollection()
            .Find(_ => true).ToListAsync();

        var entities = new List<TEntity>();
        
        if (documents is null) return entities;
        
        entities.AddRange(documents.Select(bsonDocument => BsonSerializer.Deserialize<TEntity>(bsonDocument)));

        return entities;
    }

    public virtual async Task<TEntity?> FindByIdAsync(string id)
    {
        var collection = GetCollection();
        var documentCursor = await collection
            .FindAsync(Builders<BsonDocument>.Filter.Eq("document_id", id));
        var document = await documentCursor.FirstOrDefaultAsync();
        
        if (document is null) return null;

        return BsonSerializer.Deserialize<TEntity>(document);
    }

    public virtual async Task<bool> InsertAsync<TRequest>(TRequest request)
    {
        var collection = GetCollection();
        var document = request.ToBsonDocument();
        await collection.InsertOneAsync(document);
        var result = await collection.FindAsync(Builders<BsonDocument>.Filter.AnyEq("_id", document["_id"]));
        return result.FirstOrDefault() is not null;
    }

    public virtual async Task<UpdateResult> UpdateAsync<TRequest>(string id, TRequest request)
    {
        var collection = GetCollection();
        var documentToUpdate = Builders<BsonDocument>.Filter.Eq("document_id", id);

        if (documentToUpdate is null) return null;

        return await collection.UpdateOneAsync(documentToUpdate, new BsonDocument { { "$set", request.ToBsonDocument() } });
    }

    public virtual async Task<DeleteResult> RemoveAsync(string id)
    {
        return await GetCollection().DeleteOneAsync(Builders<BsonDocument>.Filter.Eq("document_id", id));
    }
}