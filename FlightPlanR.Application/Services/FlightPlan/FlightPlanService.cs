using FlightPlanApi.Models;
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
        var result = await _flightPlanRepository.FindAllAsync();
        if (!result.Any())
            throw new NoContentException("No elements.");
        
        return result;
    }

    public async Task<FlightPlan> FindByIdAsync(string flightPlanId)
    {
        var result = await _flightPlanRepository.FindByIdAsync(flightPlanId);
        if (result is null)
        {
            throw new NotFoundException($"Document with ID: {flightPlanId} not found.");
        }
        
        return result;
    }

    public async Task InsertOneAsync(FlightPlan flightPlan)
    {
        var result = await _flightPlanRepository.InsertAsync(flightPlan);
        if (!result)
        {
            throw new BadRequestException("Inserting element failed.");
        }
    }

    public async Task UpdateAsync(FlightPlan flightPlan)
    {
        var result = await _flightPlanRepository.UpdateAsync(flightPlan);
        if (result.MatchedCount == 0 || result.ModifiedCount == 0)
        {
            throw new NotUpdatedException("No updates or element not found.");
        }
    }

    public async Task RemoveAsync(string flightPlanId)
    {
        var result = await _flightPlanRepository.RemoveAsync(flightPlanId);
        if (result.DeletedCount == 0)
        {
            throw new NotFoundException($"Removing failed. Flight plan with id {flightPlanId} not found.");
        }
    }
}