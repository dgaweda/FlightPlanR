using FlightPlanApi.Common.Extensions;
using FlightPlanR.Application.Services.FlightPlan.Requests;
using FlightPlanR.DataAccess.Repositories.FlightPlanRepository;

namespace FlightPlanR.Application.Services.FlightPlan;

public class FlightPlanService : IFlightPlanService
{
    private readonly IFlightPlanRepository _flightPlanRepository;

    public FlightPlanService(IFlightPlanRepository flightPlanRepository)
    {
        _flightPlanRepository = flightPlanRepository;
    }

    public async Task<List<DataAccess.Entity.FlightPlan>> FindAllAsync()
    {
        var result = await _flightPlanRepository.FindAllAsync()
            .ThrowIfOperationFailed();
        
        return result;
    }

    public async Task<DataAccess.Entity.FlightPlan> FindByIdAsync(string flightPlanId)
    {
        var result = await _flightPlanRepository.FindByIdAsync(flightPlanId)
            .ThrowIfOperationFailed();
        
        return result;
    }

    public async Task InsertOneAsync(AddFlightPlanRequest request)
    {
        await _flightPlanRepository.InsertAsync(request)
            .ThrowIfOperationFailed();
    }

    public async Task UpdateAsync(string id, UpdateFlightPlanRequest request)
    {
        await _flightPlanRepository.UpdateAsync(id, request)
            .ThrowIfOperationFailed();
    }

    public async Task RemoveAsync(string flightPlanId)
    {
        await _flightPlanRepository.RemoveAsync(flightPlanId)
            .ThrowIfOperationFailed();
    }
}