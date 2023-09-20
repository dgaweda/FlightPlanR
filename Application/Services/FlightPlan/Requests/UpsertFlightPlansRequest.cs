using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace FlightPlanR.Application.Services.FlightPlan.Requests;

public class UpsertFlightPlansRequest
{
	public string DocumentId { get; set; }
	
	public string? AircraftIdentification { get; set; }
    
	public string? AircraftType { get; set; }
    
	public int? AirSpeed { get; set; }
    
	public int? Altitude { get; set; }
    
	public string? FlightType { get; set; }
    
	public int? FuelHours { get; set; }
    
	public int? FuelMinutes { get; set; }
    
	public DateTime? DepartureTime { get; set; }
    
	public DateTime? ArrivalTime { get; set; }
    
	public string? DepartureAirport { get; set; }
    
	public string? ArrivalAirport { get; set; }
    
	public string? Route { get; set; }
    
	public string? Remarks { get; set; }
    
	public int? NumberOnBoard { get; set; }
}