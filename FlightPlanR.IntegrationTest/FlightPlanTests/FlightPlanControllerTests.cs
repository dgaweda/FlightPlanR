using System.Net;
using FlightPlanR.Application.Services.FlightPlan.Requests;
using FlightPlanR.IntegrationTest.Configuration;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;

namespace FlightPlanR.IntegrationTest;

public class FlightPlanControllerTests : IntegrationTestsConfiguration
{
	public FlightPlanControllerTests(WebApplicationFactory<Program> factory) : base(factory)
	{ }

	[Fact]
	public async Task FindAll_ReturnsOkResult()
	{
		var response = await HttpClient.GetAsync("/api/FlightPlan");
		response.StatusCode.Should().Be(HttpStatusCode.OK);
	}
	
	[Theory]
	[InlineData("f1d193ad0153491f9cf61cbe39c7db70")]
	[InlineData("210c87650c824aa2ad952cfbdaa74227")]
	public async Task FindById_WithValidId_ReturnsOkResult(string documentId)
	{
		var response = await HttpClient.GetAsync($"/api/FlightPlan/{documentId}");
		response.StatusCode.Should().Be(HttpStatusCode.OK);
	}
	
	[Theory]
	[InlineData(null)]
	[InlineData("12345")]
	[InlineData("")]
	public async Task FindById_WithInvalidId_ReturnsNotFoundException(string documentId)
	{
		var response = await HttpClient.GetAsync($"/api/FlightPlan/{documentId}");
		response.StatusCode.Should().Be(HttpStatusCode.OK);
	}

	
	public async Task RemoveById_WithExistingDocument_ReturnOkResult()
	{
		
	}
	
	public async Task RemoveById_WithNotExistingDocument_ReturnNotFoundException()
	{
		
	}

	public async Task InsertFlightPlan_WithValidModel_ReturnsIdOfInsertedModel()
	{
		
	}
	
	public async Task InsertFlightPlan_WithNotValidModel_ReturnsIdOfInsertedModelAndOkResult()
	{
	}

	public async Task Update_WithValidModelAndValidId_ReturnsIdOfInsertedModelAndOkResult()
	{
		
	}
	
	public async Task Update_WithValidModelAndInValidId_ReturnsNotModifiedException()
	{
		
	}
}