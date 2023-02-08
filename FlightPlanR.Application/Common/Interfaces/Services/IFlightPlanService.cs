using FlightPlanR.Application.Services.FlightPlan.Requests;

namespace FlightPlanR.Application.Services.FlightPlan;

public interface IFlightPlanService
{
    Task<List<Domain.Entities.FlightPlan>> FindAllAsync();
    Task<Domain.Entities.FlightPlan> FindByIdAsync(string flightPlanId);
    Task<string> InsertOneAsync(AddFlightPlanRequest request);
    Task<string> UpdateAsync(string id, UpdateFlightPlanRequest request);
    Task RemoveAsync(string flightPlanId);
}