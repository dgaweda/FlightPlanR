namespace FlightPlanR.DataAccess.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException(string msg) : base(msg)
    {
        
    }
}