using FlightPlanApi.Models;
using FlightPlanR.Application.Requests;
using FlightPlanR.DataAccess.Repository;

namespace FlightPlanR.Application.Services;

public interface IFlightPlanService
{
    Task<List<FlightPlan>> FindAllAsync();
    Task<FlightPlan> FindByIdAsync(string flightPlanId);
    Task InsertOneAsync(InsertFlightPlanRequest request);
    Task UpdateAsync(string id, UpdateFlightPlanRequest request);
    Task RemoveAsync(string flightPlanId);
}