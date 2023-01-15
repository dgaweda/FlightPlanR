using FlightPlanApi.Models;

namespace FlightPlanR.DataAccess.Repository;

public class FlightPlanRepository : Repository<FlightPlan>, IFlightPlanRepository
{
    public FlightPlanRepository(IMongoConfiguration mongoConfiguration) 
        : base(mongoConfiguration, mongoConfiguration.Collections[Collections.FlightPlans.ToString()])
    {
    }
}