namespace FlightPlanR.DataAccess.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string msg): base(msg)
    {
        
    }
}