﻿namespace FlightPlanApi.Common.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string msg): base(msg)
    {
        
    }
}