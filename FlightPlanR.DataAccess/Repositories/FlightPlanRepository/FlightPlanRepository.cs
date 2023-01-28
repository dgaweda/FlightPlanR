using FlightPlanApi.Common.Configuration;
using FlightPlanR.DataAccess.Entity;
using Microsoft.Extensions.Options;

namespace FlightPlanR.DataAccess.Repositories.FlightPlanRepository;

public class FlightPlanRepository : Repository<FlightPlan>, IFlightPlanRepository
{
    public FlightPlanRepository(IOptions<MongoConfiguration> mongoConfiguration) 
        : base(mongoConfiguration)
    {
    }
}