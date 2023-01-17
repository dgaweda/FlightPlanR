namespace FlightPlanR.DataAccess.Exceptions;

public class IdentityException : Exception
{
	public IdentityException() : base("Invalid token.")
	{
		
	}
}