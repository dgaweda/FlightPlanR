using FlightPlanR.DataAccess.Entity;

namespace Security.Services.CurrentUser;

public interface ICurrentUserService
{
	Task<User> GetCurrentUser();
}