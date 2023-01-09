using FlightPlanApi.Models;

namespace FlightPlanApi.Data;

public interface IDatabaseAdapter
{
    Task<List<FlightPlan>> GetAllFlightPlans();
    Task<FlightPlan> GetFlightPlanById(string flightPlanId);
    Task AddFlightPlan(FlightPlan flightPlan);
    Task UpdateFlightPlan(string flightPlanId, FlightPlan flightPlan);
    Task DeleteFlightPlan(string flightPlanId);
}