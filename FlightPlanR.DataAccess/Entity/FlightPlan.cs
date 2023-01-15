using System.Text.Json.Serialization;
using FlightPlanApi.Common;
using FlightPlanApi.Common.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace FlightPlanApi.Models;

public class FlightPlan : BaseEntity
{
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

