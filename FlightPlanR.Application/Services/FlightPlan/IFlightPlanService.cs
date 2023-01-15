using FlightPlanApi.Models;
using FlightPlanR.DataAccess.Repository;

namespace FlightPlanR.Application.Services;

public interface IFlightPlanService
{
    Task<List<FlightPlan>> FindAllAsync();
    Task<FlightPlan> FindByIdAsync(string flightPlanId);
    Task InsertOneAsync(FlightPlan flightPlan);
    Task UpdateAsync(FlightPlan flightPlan);
    Task RemoveAsync(string flightPlanId);
}