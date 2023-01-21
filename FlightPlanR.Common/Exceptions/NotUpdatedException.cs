namespace FlightPlanApi.Common.Exceptions;

public class NotUpdatedException : Exception
{
    public NotUpdatedException(string msg): base(msg)
    {
        
    }
}