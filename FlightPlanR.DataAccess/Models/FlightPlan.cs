using System.Text.Json.Serialization;
using FlightPlanApi.Common;
using FlightPlanApi.Common.Enums;
using MongoDB.Bson;

namespace FlightPlanApi.Models;

public class FlightPlan : BaseDocument<FlightPlan>
{
    [JsonPropertyName("flight_plan_id")]
    public string FlightPlanId { get; set; }
    
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

    // protected override FlightPlan? FromBsonToModel(BsonDocument? document)
    // {
    //     var flightPlan = new FlightPlan();
    //
    //     var propertyNames = flightPlan.GetJsonPropertyNames();
    //     
    //     return new FlightPlan()
    //     {
    //         FlightPlanId = document[propertyNames["FlightPlanId"]].AsString,
    //         Altitude = document[FlightPlanJsonPropertyName.Altitude.EnumDescription()].AsInt32,
    //         AirSpeed = document[FlightPlanJsonPropertyName.AirSpeed.EnumDescription()].AsInt32,
    //         AircraftIdentification = document[FlightPlanJsonPropertyName.AircraftIdentification.EnumDescription()].AsString,
    //         AircraftType = document[FlightPlanJsonPropertyName.AircraftType.EnumDescription()].AsString,
    //         ArrivalAirport = document[FlightPlanJsonPropertyName.ArrivalAirport.EnumDescription()].AsString,
    //         FlightType = document[FlightPlanJsonPropertyName.FlightType.EnumDescription()].AsString,
    //         DepartureAirport = document[FlightPlanJsonPropertyName.DepartureAirport.EnumDescription()].AsString,
    //         DepartureTime = document[FlightPlanJsonPropertyName.DepartureTime.EnumDescription()].AsBsonDateTime.ToLocalTime(),
    //         ArrivalTime = document[FlightPlanJsonPropertyName.ArrivalTime.EnumDescription()].AsBsonDateTime.ToLocalTime(),
    //         Route = document[FlightPlanJsonPropertyName.Route.EnumDescription()].AsString,
    //         Remarks = document[FlightPlanJsonPropertyName.Remarks.EnumDescription()].AsString,
    //         FuelHours = document[FlightPlanJsonPropertyName.FuelHours.EnumDescription()].AsInt32,
    //         FuelMinutes = document[FlightPlanJsonPropertyName.FuelMinutes.EnumDescription()].AsInt32,
    //         NumberOnBoard = document[FlightPlanJsonPropertyName.NumberOnBoard.EnumDescription()].AsInt32
    //     };
    // }
}

public enum FlightPlanJsonPropertyName
{
    [EnumDescription("flight_plan_id")]
    FlightPlanId,
    
    [EnumDescription("aircraft_identification")]
    AircraftIdentification,
        
    [EnumDescription("aircraft_type")]
    AircraftType,
        
    [EnumDescription("airspeed")]
    AirSpeed,
        
    [EnumDescription("altitude")]
    Altitude,
        
    [EnumDescription("flight_type")]
    FlightType,
        
    [EnumDescription("fuel_hours")]
    FuelHours,
        
    [EnumDescription("fuel_minutes")]
    FuelMinutes,
        
    [EnumDescription("departure_time")]
    DepartureTime,
        
    [EnumDescription("estimated_arrival_time")]
    ArrivalTime,
        
    [EnumDescription("departing_airport")]
    DepartureAirport,
        
    [EnumDescription("arrival_airport")]
    ArrivalAirport,
        
    [EnumDescription("route")]
    Route,
        
    [EnumDescription("remarks")]
    Remarks,
        
    [EnumDescription("number_onboard")]
    NumberOnBoard,
}

