﻿using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace FlightPlanR.Application.Services.FlightPlan.Requests;

public record AddFlightPlanRequest
{
	[BsonElement("document_id")]
	[JsonIgnore]
	public string DocumentId { get; set; } = Guid.NewGuid().ToString("N");
	
	[BsonElement("aircraft_identification")]
	public string? AircraftIdentification { get; set; }
    
	[BsonElement("aircraft_type")]
	public string? AircraftType { get; set; }
    
	[BsonElement("airspeed")]
	public int? AirSpeed { get; set; }
    
	[BsonElement("altitude")]
	public int? Altitude { get; set; }
    
	[BsonElement("flight_type")]
	public string? FlightType { get; set; }
    
	[BsonElement("fuel_hours")]
	public int? FuelHours { get; set; }
    
	[BsonElement("fuel_minutes")]
	public int? FuelMinutes { get; set; }
    
	[BsonElement("departure_time")]
	public DateTime? DepartureTime { get; set; }
    
	[BsonElement("estimated_arrival_time")]
	public DateTime? ArrivalTime { get; set; }
    
	[BsonElement("departing_airport")]
	public string? DepartureAirport { get; set; }
    
	[BsonElement("arrival_airport")]
	public string? ArrivalAirport { get; set; }
    
	[BsonElement("route")]
	public string? Route { get; set; }
    
	[BsonElement("remarks")]
	public string? Remarks { get; set; }
    
	[BsonElement("number_onboard")]
	public int? NumberOnBoard { get; set; }
}