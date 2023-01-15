
using FlightPlanApi.Models;
using FlightPlanR.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanApi.Controllers;
public class FlightPlanController : BaseController
{
    private readonly IFlightPlanRepository _flightPlanRepository;

    public FlightPlanController(IFlightPlanRepository flightPlanRepository)
    {
        _flightPlanRepository = flightPlanRepository;
    }

    [HttpGet]
    public async Task<IActionResult> FindAll()
    {
        await _flightPlanRepository.FindAllAsync();
        return Ok();
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> FindById([FromRoute] string id)
    {
        await _flightPlanRepository.FindByIdAsync(id);
        return Ok();
    }
    
    [HttpPost]
    public async Task<IActionResult> Insert(FlightPlan flightPlan)
    {
        await _flightPlanRepository.InsertAsync(flightPlan);
        return Ok();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromRoute] string id, FlightPlan flightPlan)
    {
        await _flightPlanRepository.UpdateAsync(id, flightPlan);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        await _flightPlanRepository.RemoveAsync(id);
        return Ok();
    }
}

