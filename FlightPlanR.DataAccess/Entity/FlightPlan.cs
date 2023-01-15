﻿using System.Text.Json.Serialization;
using FlightPlanApi.Common;
using FlightPlanApi.Common.Enums;
using MongoDB.Bson;

namespace FlightPlanApi.Models;

public class FlightPlan : BaseEntity
{
    [JsonPropertyName("aircraft_identification")]
    public string AircraftIdentification { get; set; }
    
    [JsonPropertyName("aircraft_type")]
    public string AircraftType { get; set; }
    
    [JsonPropertyName("airspeed")]
    public int AirSpeed { get; set; }
    
    [JsonPropertyName("altitude")]
    public int Altitude { get; set; }
    
    [JsonPropertyName("flight_type")]
    public string FlightType { get; set; }
    
    [JsonPropertyName("fuel_hours")]
    public int FuelHours { get; set; }
    
    [JsonPropertyName("fuel_minutes")]
    public int FuelMinutes { get; set; }
    
    [JsonPropertyName("departure_time")]
    public DateTime DepartureTime { get; set; }
    
    [JsonPropertyName("estimated_arrival_time")]
    public DateTime ArrivalTime { get; set; }
    
    [JsonPropertyName("departing_airport")]
    public string DepartureAirport { get; set; }
    
    [JsonPropertyName("arrival_airport")]
    public string ArrivalAirport { get; set; }
    
    [JsonPropertyName("route")]
    public string Route { get; set; }
    
    [JsonPropertyName("remarks")]
    public string Remarks { get; set; }
    
    [JsonPropertyName("number_onboard")]
    public int NumberOnBoard { get; set; }
}

