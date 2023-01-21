using FlightPlanApi.Models;
using Microsoft.Extensions.Options;

namespace FlightPlanR.DataAccess.Repository;

public class FlightPlanRepository : Repository<FlightPlan>, IFlightPlanRepository
{
    public FlightPlanRepository(IOptions<MongoConfiguration> mongoConfiguration, string collectionName) 
        : base(mongoConfiguration, collectionName)
    {
    }
}