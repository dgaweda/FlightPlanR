using FlightPlanApi.Common.Enums;
using FlightPlanApi.Models;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlightPlanApi.Data;

public class MongoDbDatabase
{
    private IMongoCollection<BsonDocument> GetCollection(string databaseName, string collectionName)
    {
        var client = new MongoClient();
        var database = client.GetDatabase(databaseName);
        return database.GetCollection<BsonDocument>(collectionName);
    }

    private FlightPlan? ConvertBsonToFlightPlan(BsonDocument? document)
    {
        if (document is null) return null;

        return new FlightPlan()
        {
            FlightPlanId = document[FlightPlanJsonPropertyName.FlightPlanId.EnumDescription()].AsString,
            Altitude = document[FlightPlanJsonPropertyName.Altitude.EnumDescription()].AsInt32,
            AirSpeed = document[FlightPlanJsonPropertyName.AirSpeed.EnumDescription()].AsInt32,
            AircraftIdentification = document[FlightPlanJsonPropertyName.AircraftIdentification.EnumDescription()].AsString,
            AircraftType = document[FlightPlanJsonPropertyName.AircraftType.EnumDescription()].AsString,
            ArrivalAirport = document[FlightPlanJsonPropertyName.ArrivalAirport.EnumDescription()].AsString,
            FlightType = document[FlightPlanJsonPropertyName.FlightType.EnumDescription()].AsString,
            DepartureAirport = document[FlightPlanJsonPropertyName.DepartureAirport.EnumDescription()].AsString,
            DepartureTime = document[FlightPlanJsonPropertyName.DepartureTime.EnumDescription()].AsBsonDateTime.ToLocalTime(),
            ArrivalTime = document[FlightPlanJsonPropertyName.ArrivalTime.EnumDescription()].AsBsonDateTime.ToLocalTime(),
            Route = document[FlightPlanJsonPropertyName.Route.EnumDescription()].AsString,
            Remarks = document[FlightPlanJsonPropertyName.Remarks.EnumDescription()].AsString,
            FuelHours = document[FlightPlanJsonPropertyName.FuelHours.EnumDescription()].AsInt32,
            FuelMinutes = document[FlightPlanJsonPropertyName.FuelMinutes.EnumDescription()].AsInt32,
            NumberOnBoard = document[FlightPlanJsonPropertyName.NumberOnBoard.EnumDescription()].AsInt32
        };
    }
}