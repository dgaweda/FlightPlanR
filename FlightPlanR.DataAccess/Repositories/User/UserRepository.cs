using Microsoft.Extensions.Options;

namespace FlightPlanR.DataAccess.Repository.User;

public class UserRepository : Repository<FlightPlanApi.Models.User>, IUserRepository
{
	public UserRepository(IOptions<MongoConfiguration> configuration, string collectionName) 
		: base(configuration, collectionName)
	{
	}
}