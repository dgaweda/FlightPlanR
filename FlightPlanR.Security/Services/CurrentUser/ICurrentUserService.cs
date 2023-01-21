using FlightPlanApi.Models;

namespace FlightPlanR.Security.Services.CurrentUser;

public interface ICurrentUserService
{
	Task<User> GetCurrentUser();
}