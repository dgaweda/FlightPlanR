using System.Reflection;
using System.Text.Json.Serialization;
using FlightPlanApi.Common.Enums;
using FlightPlanApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlightPlanApi.Data;

public class MongoDbDatabase : IDatabaseAdapter
{
    private IMongoCollection<BsonDocument> GetCollection(string databaseName, string collectionName)
    {
        var client = new MongoClient();
        var database = client.GetDatabase(databaseName);
        return database.GetCollection<BsonDocument>(collectionName);
    }

    public Task<List<FlightPlan>> GetAllFlightPlans()
    {
        throw new NotImplementedException();
    }

    public Task<FlightPlan> GetFlightPlanById(string flightPlanId)
    {
        throw new NotImplementedException();
    }

    public Task AddFlightPlan(FlightPlan flightPlan)
    {
        throw new NotImplementedException();
    }

    public Task UpdateFlightPlan(string flightPlanId, FlightPlan flightPlan)
    {
        throw new NotImplementedException();
    }

    public Task DeleteFlightPlan(string flightPlanId)
    {
        throw new NotImplementedException();
    }
}