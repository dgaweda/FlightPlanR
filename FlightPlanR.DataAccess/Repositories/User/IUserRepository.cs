namespace FlightPlanR.DataAccess.Repository.User;

public interface IUserRepository : IRepository<FlightPlanApi.Models.User>
{
	Task<FlightPlanApi.Models.User> FindByUsername(string username);
	Task<bool> CheckIfUsernameIsTaken(string username);
}