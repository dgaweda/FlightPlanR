﻿using FlightPlanR.Application.Common.Interfaces;
using FlightPlanR.Domain.Common;
using FlightPlanR.Domain.Common.Attributes;
using FlightPlanR.Infrastructure.Common;
using FlightPlanR.Infrastructure.Common.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlightPlanR.Infrastructure.Repository;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
{
    private readonly IMongoDatabase _database;
    protected readonly IMongoCollection<TEntity> Collection;

    public Repository(MongoConfiguration configuration, IMongoClient mongoClient)
    {
        _database = mongoClient.GetDatabase(configuration.DbName);
        Collection = GetCollection();
    }
    
    protected IMongoCollection<TEntity> GetCollection() =>
        _database.GetCollection<TEntity>(GetCollectionName());

    private string GetCollectionName() => typeof(TEntity).GetAttributeFromClass<MongoCollectionAttribute>().CollectionName;

    public virtual async Task<List<TEntity>> FindAllAsync()
    {
        var entities = await Collection.Find(_ => true).ToListAsync();
        return entities ?? new List<TEntity>();
    }

    public virtual async Task<TEntity?> FindByIdAsync(string id)
    {
        var documentCursor = await Collection.FindAsync(x => x.DocumentId == id);
        var entity = await documentCursor.FirstOrDefaultAsync();

        return entity;
    }

    public virtual async Task<string> InsertAsync(TEntity entity)
    {
        await Collection.InsertOneAsync(entity);
        var result = await Collection.FindAsync(x => x.DocumentId == entity.DocumentId);
        return result.FirstOrDefault().Id;
    }

    public virtual async Task<UpdateResult> UpdateAsync(string id, TEntity entity)
    {
        var collection = _database.GetCollection<BsonDocument>(GetCollectionName());
        var documentToUpdate = Builders<BsonDocument>.Filter.Eq("document_id", id);

        if (documentToUpdate is null) return null;

        return await collection.UpdateOneAsync(documentToUpdate, new BsonDocument { { "$set", entity.ToBsonDocument() } });
    }

    public virtual async Task<DeleteResult> RemoveAsync(string id)
    {
        return await Collection.DeleteOneAsync(x => x.DocumentId == id);
    }
}