using FlightPlanApi.Controllers.Base;
using FlightPlanR.Application.Services.FlightPlan;
using FlightPlanR.Application.Services.FlightPlan.Requests;
using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous]
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
    public async Task<IActionResult> Insert(AddFlightPlanRequest flightPlanRequest)
    {
        await _flightPlanService.InsertOneAsync(flightPlanRequest);
        return Ok();
    }
    
    [HttpPut("{documentId}")]
    public async Task<IActionResult> Update(string documentId, UpdateFlightPlanRequest flightPlan)
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

