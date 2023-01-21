using FlightPlanR.Application.Services.FlightPlan.Requests;

namespace FlightPlanR.Application.Services.FlightPlan;

public interface IFlightPlanService
{
    Task<List<DataAccess.Entity.FlightPlan>> FindAllAsync();
    Task<DataAccess.Entity.FlightPlan> FindByIdAsync(string flightPlanId);
    Task InsertOneAsync(AddFlightPlanRequest request);
    Task UpdateAsync(string id, UpdateFlightPlanRequest request);
    Task RemoveAsync(string flightPlanId);
}