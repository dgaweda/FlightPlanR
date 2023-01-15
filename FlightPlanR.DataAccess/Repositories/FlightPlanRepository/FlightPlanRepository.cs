using FlightPlanApi.Models;
using Microsoft.Extensions.Options;

namespace FlightPlanR.DataAccess.Repository;

public class FlightPlanRepository : Repository<FlightPlan>, IFlightPlanRepository
{
    public FlightPlanRepository(IOptions<MongoConfiguration> mongoConfiguration) 
        : base(mongoConfiguration, mongoConfiguration.Value.Collections[Collections.FlightPlans.ToString()])
    {
    }
}