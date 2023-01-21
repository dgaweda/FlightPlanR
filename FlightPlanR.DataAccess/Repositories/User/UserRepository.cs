﻿using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace FlightPlanR.DataAccess.Repository.User;

public class UserRepository : Repository<FlightPlanApi.Models.User>, IUserRepository
{
	private readonly string _collectionName;
	public UserRepository(IOptions<MongoConfiguration> configuration, string collectionName) 
		: base(configuration, collectionName)
	{
		_collectionName = collectionName;
	}

	public async Task<FlightPlanApi.Models.User> FindByUsername(string username)
	{
		var documentCursor = await GetCollection(_collectionName)
			.FindAsync(Builders<BsonDocument>.Filter.Eq("username", username));
		var document = await documentCursor.FirstOrDefaultAsync();
		if (document is null) return null;

		var user = BsonSerializer.Deserialize<FlightPlanApi.Models.User>(document);
		return user;
	}

	public async Task<bool> CheckIfUsernameIsTaken(string username)
	{
		var user = await FindByUsername(username);
		return user is null;
	}
}