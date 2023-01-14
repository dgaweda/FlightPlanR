using System.Net;
using FlightPlanApi.Data;
using FlightPlanApi.Models;
using FluentAssertions;
using MongoDB.Bson;
using Moq;
using Xunit;

namespace FlightPlanR.Tests;

public class MongoDbDatabaseTests
{
    private readonly Mock<IDatabaseAdapter> _mongoDbAdapterMock;

    public MongoDbDatabaseTests()
    {
        _mongoDbAdapterMock = new Mock<IDatabaseAdapter>();
    }
    // #region ConvertBsonDocToObject
    // [Fact]
    // public void ConvertBsonDocToObject_ConversionToFlightPlanObject_FlightPlanObject()
    // {
    //     
    // }
    //
    // [Fact]
    // public void ConvertBsonDocToObject_ConversionToInvalidObject_Exception()
    // {
    //     
    // }
    //
    // [Fact]
    // public void ConvertBsonDocToObject_ConversionFromEmptyDoc_EmptyObject()
    // {
    //     
    // }
    //
    //
    // #endregion
    

    #region GetFlightPlanById
    [Fact]
    public void GetFlightPlanById_WhenFlightPlanExits_FlightPlan()
    {
        _mongoDbAdapterMock.Setup(m => m.GetFlightPlanById(It.IsAny<string>()))
            .ReturnsAsync(new FlightPlan());
    }
    
    [Fact]
    public void GetFlightPlanById_WhenFlightPlanNotExist_404HttpCode()
    {
        _mongoDbAdapterMock.Setup(m => m.GetFlightPlanById(It.IsAny<string>()))
            .Throws(new Exception());

    }
    #endregion

    #region AddFlightPlan
    [Fact]
    public void AddFlightPlan_ProperFlightPlan_CompletedTask()
    {
        _mongoDbAdapterMock.SetupAsync(m => m.AddFlightPlan(It.IsAny<FlightPlan>()));
    }
    
    public void AddFlightPlan_InvalidFlightPlan_400HttpCode()
    {
        _mongoDbAdapterMock
            .SetupAsync(m => m.AddFlightPlan(It.IsAny<FlightPlan>()))
            .Throws(new Exception());
    }
    #endregion

    #region UpdateFlightPlan
    [Fact]
    public void UpdateFlightPlan_ProperFlightPlanObject_CompletedTask()
    {
        _mongoDbAdapterMock
            .SetupAsync(m => m.UpdateFlightPlan(It.IsAny<string>(),It.IsAny<FlightPlan>()));
    }
    
    [Fact]
    public void UpdateFlightPlan_NotExistingFlightPlanObject_404HttpCode()
    {
        _mongoDbAdapterMock
            .SetupAsync(m => m.UpdateFlightPlan(It.IsAny<string>(), It.IsAny<FlightPlan>()))
            .Throws(new Exception());
    }
    
    [Fact]
    public void UpdateFlightPlan_InvalidFlightPlanObject_400HttpCode()
    {
        _mongoDbAdapterMock
            .SetupAsync(m => m.UpdateFlightPlan(It.IsAny<string>(), It.IsAny<FlightPlan>()))
            .Throws(new Exception());
    }
    #endregion

    #region DeleteFlightPlan
    [Fact]
    public void DeleteFlightPlan_ExistingFlightPlan_CompletedTask()
    {
        _mongoDbAdapterMock.SetupAsync(m => m.DeleteFlightPlan(It.IsAny<string>()));
    }
    
    [Fact]
    public void DeleteFlightPlan_NotExistingFlightPlan_404ErrorCode()
    {
        _mongoDbAdapterMock
            .SetupAsync(m => m.UpdateFlightPlan(It.IsAny<string>(), It.IsAny<FlightPlan>()))
            .Throws(new Exception());
    }
    #endregion

    #region ConversionFromBsonToModel
    [Fact]
    public void ConvertBsonToFlightPlan_WithStringConversion_ConvertedFlightPlan()
    {
        var data = new Dictionary<string, object> { { "aircraft_type", "sample aircraft type" } };

        var result = new FlightPlan().FromBsonToModel(new BsonDocument(data));
    
        result.Should().BeOfType<FlightPlan>();
        result.AircraftType.Should().Be("sample aircraft type");
    }
    
    [Fact]
    public void ConvertBsonToFlightPlan_WithIntConversion_ConvertedFlightPlan()
    {
        var data = new Dictionary<string, object> { { "airspeed", 25 } };

        var result = new FlightPlan().FromBsonToModel(new BsonDocument(data));
    
        result.Should().BeOfType<FlightPlan>();
        result.AirSpeed.Should().Be(25);
    }
    
    [Fact]
    public void ConvertBsonToFlightPlan_FromBsonToDateTime_ConvertedFlightPlan()
    {
        var data = new Dictionary<string, object> { { "departure_time", new DateTime(2023, 1,1) } };

        var result = new FlightPlan().FromBsonToModel(new BsonDocument(data));
    
        result.Should().BeOfType<FlightPlan>();
        result.DepartureTime.Should().Be(new DateTime(2023, 1, 1));
    }
    
    [Fact]
    public void ConvertBsonToFlightPlan_WithInvalidPropertyTypeConversion_ConvertedFlightPlan()
    {
        var data = new Dictionary<string, object> { { "departure_time", 99 } };

        var func = () => new FlightPlan().FromBsonToModel(new BsonDocument(data)).Should();
        
        func.Should().Throw<InvalidCastException>();
    }
    #endregion
}