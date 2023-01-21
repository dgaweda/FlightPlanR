using Microsoft.Extensions.Options;

namespace FlightPlanR.DataAccess;

public class MongoConfiguration
{
    public string ConnectionString { get; set; }
    public string Name { get; set; }
}