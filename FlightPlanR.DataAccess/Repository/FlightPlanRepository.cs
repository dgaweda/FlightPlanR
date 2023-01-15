using System.Text.Json;
using FlightPlanApi.Common;
using FlightPlanApi.Models;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using JsonReader = Newtonsoft.Json.JsonReader;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace FlightPlanR.DataAccess.Repository;

public class FlightPlanRepository : Repository<FlightPlan>, IFlightPlanRepository
{
    private readonly IMongoConfiguration _mongoConfiguration;
    private readonly Dictionary<string, string> _collections;
    private readonly Dictionary<string, string> _flightPlanPropertyNames;

    public FlightPlanRepository(IMongoConfiguration mongoConfiguration)
    {
        _mongoConfiguration = mongoConfiguration;
        _collections = _mongoConfiguration.Collections;
        _flightPlanPropertyNames = new FlightPlan().GetEntityPropertyNames();
    }

    public override async Task<List<FlightPlan>> FindAllAsync()
    {
        var documents = await GetCollection(_mongoConfiguration.Name ,_collections[Collections.FlightPlans.ToString()])
            .Find(_ => true).ToListAsync();

        var flightPlans = new List<FlightPlan>();
        if (documents is null) return flightPlans;
        foreach (var bsonDocument in documents)
        {
            var converted = bsonDocument.ToJson();
            var convertedObject = JObject.Parse(converted).ToObject<FlightPlan>();
            flightPlans.Add(convertedObject);
        }

        return flightPlans;
    }

    public override async Task<FlightPlan> FindByIdAsync(string flightPlanId)
    {
        var collection = GetCollection(_mongoConfiguration.Name, _collections[Collections.FlightPlans.ToString()]);
        var flightPlanCursor = await collection
            .FindAsync(Builders<BsonDocument>.Filter.Eq(_flightPlanPropertyNames["Id"], flightPlanId));
        var document = await flightPlanCursor.FirstOrDefaultAsync();

        var flightPlan = JObject.Parse(document.ToJson()).ToObject<FlightPlan>();
        return flightPlan ?? new FlightPlan();
    }

    public override async Task InsertAsync(FlightPlan flightPlan)
    {
        await GetCollection(_mongoConfiguration.Name, _collections[Collections.FlightPlans.ToString()])
            .InsertOneAsync(flightPlan.ToJson().ToBsonDocument());
    }

    public override async Task UpdateAsync(string flightPlanId, FlightPlan flightPlan)
    {
        await RemoveAsync(flightPlanId);
        await InsertAsync(flightPlan);
    }

    public override async Task RemoveAsync(string flightPlanId)
    {
        await GetCollection(_mongoConfiguration.Name, _collections[Collections.FlightPlans.ToString()])
            .DeleteOneAsync(Builders<BsonDocument>.Filter.Eq(_flightPlanPropertyNames["Id"], flightPlanId));
        
    }
}