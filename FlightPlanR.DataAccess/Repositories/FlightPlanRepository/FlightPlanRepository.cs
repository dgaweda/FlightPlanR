using FlightPlanApi.Common.Configuration;
using FlightPlanR.DataAccess.Entity;
using Microsoft.Extensions.Options;

namespace FlightPlanR.DataAccess.Repositories.FlightPlanRepository;

public class FlightPlanRepository : Repository<FlightPlan>, IFlightPlanRepository
{
    private static readonly string _collectionName = "flight_plans";
    public FlightPlanRepository(IOptions<MongoConfiguration> mongoConfiguration) 
        : base(mongoConfiguration, _collectionName)
    {
    }
}