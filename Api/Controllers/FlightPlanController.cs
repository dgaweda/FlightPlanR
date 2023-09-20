using System.Collections.ObjectModel;
using FlightPlanApi.Controllers.Base;
using FlightPlanR.Application.Services.FlightPlan;
using FlightPlanR.Application.Services.FlightPlan.Requests;
using FlightPlanR.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightPlanApi.Controllers;

[Route("api/flight-plan")]
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
    
    [HttpGet("{documentId}")]
    public async Task<IActionResult> FindById(string documentId)
    {
        return Ok(await _flightPlanService.FindByIdAsync(documentId));
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
    
    [HttpDelete("{documentId}")]
    public async Task<IActionResult> Delete(string documentId)
    {
        await _flightPlanService.RemoveAsync(documentId);
        return Ok();
    }

    [HttpGet("route/time/{documentId}")]
    public async Task<IActionResult> GetFlightPlanTimeEnroute(string documentId)
    {
        return Ok(await _flightPlanService.GetFlightPlanEnroute(documentId));
    }

    [HttpPost("upsert-many")]
    [AllowAnonymous]
    public async Task<IActionResult> UpsertMany([FromBody] List<UpsertFlightPlansRequest> request)
    {
        await _flightPlanService.UpsertManyAsync(request);
        return Ok();
    }
}

