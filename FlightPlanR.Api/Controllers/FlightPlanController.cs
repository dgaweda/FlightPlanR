
using FlightPlanApi.Models;
using FlightPlanR.Application.Services;
using FlightPlanR.DataAccess.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanApi.Controllers;
public class FlightPlanController : BaseController
{
    private readonly IFlightPlanService _flightPlanService;

    public FlightPlanController(IFlightPlanService flightPlanService)
    {
        _flightPlanService = flightPlanService;
    }

    [HttpGet]
    public async Task<IActionResult> FindAll()
    {
        var result = await _flightPlanService.FindAllAsync();
        return Ok(result);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> FindById([FromRoute] string id)
    {
        var result = await _flightPlanService.FindByIdAsync(id);
        return Ok(result);
    }
    
    [HttpPost]
    public async Task<IActionResult> Insert(FlightPlan flightPlan)
    {
        await _flightPlanService.InsertOneAsync(flightPlan);
        return Ok();
    }
    
    [HttpPut("{documentId}")]
    public async Task<IActionResult> Update(string documentId, FlightPlan flightPlan)
    {
        await _flightPlanService.UpdateAsync(documentId, flightPlan);
        return Ok();
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        await _flightPlanService.RemoveAsync(id);
        return Ok();
    }
    
    [HttpGet("route/{id}")]
    public async Task<IActionResult> GetFlightPlanRoute([FromRoute] string id)
    {
        throw new NotImplementedException();
        // TODO: implement method 
    }
    
    [HttpGet("route/time/{id}")]
    public async Task<IActionResult> GetFlightPlanTimeEnroute([FromRoute] string id)
    {
        throw new NotImplementedException();
        // TODO: implement method
    }
}

