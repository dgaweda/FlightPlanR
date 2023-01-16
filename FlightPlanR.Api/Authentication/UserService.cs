namespace FlightPlanApi.Authentication;

public class UserService : IUserService
{
  public Task<User> Authenticate(string username, string password)
  {
    if (username != "admin" || password != "password")
    {
      return Task.FromResult<User>(null);
    }

    return Task.FromResult(new User()
    {
      Username = username,
      Password = password,
      Id = Guid.NewGuid().ToString("N")
    });
  }
}