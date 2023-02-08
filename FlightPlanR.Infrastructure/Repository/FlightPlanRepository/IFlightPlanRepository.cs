using FlightPlanR.Domain.Entities;
using FlightPlanR.Infrastructure.Repository;

namespace FlightPlanR.Infrastructure.Repository.FlightPlanRepository;

public interface IFlightPlanRepository : IRepository<FlightPlan>
{
}