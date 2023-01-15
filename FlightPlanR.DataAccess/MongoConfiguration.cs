namespace FlightPlanR.DataAccess;

public interface IMongoConfiguration
{
    string ConnectionString { get; set; }
    string Name { get; set; }
    Dictionary<string, string> Collections { get; set; }
}

public class MongoConfiguration : IMongoConfiguration
{
    public string ConnectionString { get; set; }
    public string Name { get; set; }
    public Dictionary<string, string> Collections { get; set; }
}

public enum Collections
{
    FlightPlans
}