using FlightPlanApi.Models;
using FlightPlanR.Application.Extensions;
using FlightPlanR.DataAccess.Exceptions;
using FlightPlanR.DataAccess.Repository;

namespace FlightPlanR.Application.Services;

public class FlightPlanService : IFlightPlanService
{
    private readonly IFlightPlanRepository _flightPlanRepository;

    public FlightPlanService(IFlightPlanRepository flightPlanRepository)
    {
        _flightPlanRepository = flightPlanRepository;
    }

    public async Task<List<FlightPlan>> FindAllAsync()
    {
        var result = await _flightPlanRepository.FindAllAsync()
            .ThrowIfOperationFailed();
        
        return result;
    }

    public async Task<FlightPlan> FindByIdAsync(string flightPlanId)
    {
        var result = await _flightPlanRepository.FindByIdAsync(flightPlanId)
            .ThrowIfOperationFailed();
        
        return result;
    }

    public async Task InsertOneAsync(FlightPlan flightPlan)
    {
        await _flightPlanRepository.InsertAsync(flightPlan)
            .ThrowIfOperationFailed();
    }

    public async Task UpdateAsync(string id, FlightPlan flightPlan)
    {
        await _flightPlanRepository.UpdateAsync(id, flightPlan)
            .ThrowIfOperationFailed();
    }

    public async Task RemoveAsync(string flightPlanId)
    {
        await _flightPlanRepository.RemoveAsync(flightPlanId)
            .ThrowIfOperationFailed();
    }
}