using AutoMapper;
using FlightPlanApi.Common.Extensions;
using FlightPlanR.Application.Services.FlightPlan.Requests;
using FlightPlanR.DataAccess.Repositories.FlightPlanRepository;

namespace FlightPlanR.Application.Services.FlightPlan;

public class FlightPlanService : IFlightPlanService
{
    private readonly IFlightPlanRepository _flightPlanRepository;
    private readonly IMapper _mapper;

    public FlightPlanService(IFlightPlanRepository flightPlanRepository, IMapper mapper)
    {
        _flightPlanRepository = flightPlanRepository;
        _mapper = mapper;
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

    public async Task<string> InsertOneAsync(AddFlightPlanRequest request)
    {
        var result = _mapper.Map<DataAccess.Entity.FlightPlan>(request);
        await _flightPlanRepository.InsertAsync(result)
            .ThrowIfOperationFailed();
        return result.DocumentId;
    }

    public async Task<string> UpdateAsync(string id, UpdateFlightPlanRequest request)
    {
        var result = _mapper.Map<DataAccess.Entity.FlightPlan>(request);
        await _flightPlanRepository.UpdateAsync(id, result)
            .ThrowIfOperationFailed();

        return result.DocumentId;
    }

    public async Task RemoveAsync(string flightPlanId)
    {
        await _flightPlanRepository.RemoveAsync(flightPlanId)
            .ThrowIfOperationFailed();
    }
}