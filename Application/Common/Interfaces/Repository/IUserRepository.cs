namespace FlightPlanR.Application.Common.Interfaces;

public interface IUserRepository : IRepository<Domain.Entities.User>
{
	Task<Domain.Entities.User> FindByUsername(string username);
	Task<bool> CheckIfUsernameIsTaken(string username);
}