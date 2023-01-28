using FlightPlanApi.Common.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

namespace FlightPlanR.DataAccess.Repositories.User;

public class UserRepository : Repository<Entity.User>, IUserRepository
{
	public UserRepository(IOptions<MongoConfiguration> configuration) 
		: base(configuration)
	{
	}

	public async Task<Entity.User> FindByUsername(string username)
	{
		var documentCursor = await GetCollection().FindAsync(Builders<BsonDocument>.Filter.Eq("username", username));
		var document = await documentCursor.FirstOrDefaultAsync();
		if (document is null) return null;

		var user = BsonSerializer.Deserialize<Entity.User>(document);
		return user;
	}

	public async Task<bool> CheckIfUsernameIsTaken(string username)
	{
		var user = await FindByUsername(username);
		return user is null;
	}
}