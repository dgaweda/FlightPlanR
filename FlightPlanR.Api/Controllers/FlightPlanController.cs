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
        return Ok(await _flightPlanService.FindAllAsync());
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> FindById([FromRoute] string id)
    {
        return Ok(await _flightPlanService.FindByIdAsync(id));
    }
    
    [HttpPost]
    public async Task<IActionResult> Insert(AddFlightPlanRequest flightPlanRequest)
    {
        
        return Ok(await _flightPlanService.InsertOneAsync(flightPlanRequest));
    }
    
    [HttpPut("{documentId}")]
    public async Task<IActionResult> Update(string documentId, UpdateFlightPlanRequest flightPlan)
    {
        return Ok(await _flightPlanService.UpdateAsync(documentId, flightPlan));
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

