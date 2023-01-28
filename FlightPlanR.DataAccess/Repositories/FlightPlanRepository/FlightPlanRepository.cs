using FlightPlanApi.Common.Configuration;
using FlightPlanR.DataAccess.Entity;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace FlightPlanR.DataAccess.Repositories.FlightPlanRepository;

public class FlightPlanRepository : Repository<FlightPlan>, IFlightPlanRepository
{
    public FlightPlanRepository(MongoConfiguration mongoConfiguration, IMongoClient mongoClient) 
        : base(mongoConfiguration, mongoClient)
    {
    }
}