using FlightPlanApi.Common.Configuration;
using MongoDB.Driver;

namespace FlightPlanR.DataAccess.Repositories.User;

public class UserRepository : Repository<Entity.User>, IUserRepository
{
	public UserRepository(MongoConfiguration configuration, IMongoClient mongoClient) 
		: base(configuration, mongoClient)
	{
	}

	public async Task<Entity.User> FindByUsername(string username)
	{
		var collectionCursor = await Collection.FindAsync(x => x.Username == username);
		var user = await collectionCursor.FirstOrDefaultAsync();
		return user ?? null;
	}

	public async Task<bool> CheckIfUsernameIsTaken(string username)
	{
		var user = await FindByUsername(username);
		return user is null;
	}
}