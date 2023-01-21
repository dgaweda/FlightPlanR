namespace FlightPlanR.DataAccess.Repositories.User;

public interface IUserRepository : IRepository<Entity.User>
{
	Task<Entity.User> FindByUsername(string username);
	Task<bool> CheckIfUsernameIsTaken(string username);
}