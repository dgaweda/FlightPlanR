namespace FlightPlanR.DataAccess;

public class MongoConfiguration
{
    public string ConnectionString { get; set; }
    public string Name { get; set; }
    public Dictionary<string, string> Collections { get; set; }
}

public enum Collections
{
    FlightPlans
}