namespace FlightPlanR.Application.Common.Exceptions;

public class IdentityException : Exception
{
	public IdentityException(string? message = "Unauthorized") : base(message)
	{
		
	}
}