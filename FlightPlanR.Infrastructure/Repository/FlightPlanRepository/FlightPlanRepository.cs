using FlightPlanR.Domain.Entities;
using FlightPlanR.Infrastructure.Common.Configuration;
using MongoDB.Driver;

namespace FlightPlanR.Infrastructure.Repository.FlightPlanRepository;

public class FlightPlanRepository : Repository<FlightPlan>, IFlightPlanRepository
{
    public FlightPlanRepository(MongoConfiguration mongoConfiguration, IMongoClient mongoClient) 
        : base(mongoConfiguration, mongoClient)
    {
    }
}