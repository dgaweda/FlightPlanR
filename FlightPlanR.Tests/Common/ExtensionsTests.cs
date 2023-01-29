using FlightPlanApi.Common.Exceptions;
using FlightPlanApi.Common.Extensions;
using FlightPlanR.DataAccess.Entity;
using FlightPlanR.Tests.Common.FakeModels;
using FluentAssertions;
using MongoDB.Driver;
using Xunit;

namespace FlightPlanR.Tests.Common;

public class ExtensionsTests
{
	[Fact]
	public async Task ThrowIfOperationFailed_WithEmptyList_NoContentException()
	{
		var emptyList =  Task.FromResult(new List<FlightPlan>());
		
		await emptyList.Invoking(x => x.ThrowIfOperationFailed())
			.Should()
			.ThrowAsync<NoContentException>()
			.WithMessage("No elements.");
	}
	
	[Fact]
	public async Task ThrowIfOperationFailed_WithFilledList_FilledList()
	{
		var emptyList =  Task.FromResult(new List<FlightPlan>() { new FlightPlan(), new FlightPlan()});

		var result = await emptyList.ThrowIfOperationFailed();

		result.Should().HaveCount(2);
		result.Should().BeEquivalentTo(new List<FlightPlan>() { new FlightPlan(), new FlightPlan() });
	}
	
	[Fact]
	public async Task ThrowIfOperationFailed_WithFalseInput_BadRequestException()
	{
		var falseResult =  Task.FromResult(false);

		var result = falseResult.Invoking(x => x.ThrowIfOperationFailed())
			.Should()
			.ThrowAsync<BadRequestException>()
			.WithMessage("Operation failed.");
	}
	
	[Fact]
	public async Task ThrowIfOperationFailed_WithTrueInput()
	{
		var falseResult =  Task.FromResult(true);

		await falseResult.Invoking(x => x.ThrowIfOperationFailed())
			.Should()
			.NotThrowAsync();
	}
	
	[Fact]
	public async Task ThrowIfOperationFailed_WithDeleteResultDeletedCountZero_NotFoundException()
	{
		var deleteResult =  Task.FromResult((DeleteResult)new FakeDeleteResult(0, true));

		await deleteResult.Invoking(x => x.ThrowIfOperationFailed())
			.Should()
			.ThrowAsync<NotFoundException>()
			.WithMessage("No document removed.");
	}
	
	[Fact]
	public async Task ThrowIfOperationFailed_WithDeleteResultDeletedCountMoreThanZero()
	{
		var deleteResult =  Task.FromResult((DeleteResult)new FakeDeleteResult(1, true));

		await deleteResult.Invoking(x => x.ThrowIfOperationFailed())
			.Should()
			.NotThrowAsync();
	}
	
	[Fact]
	public async Task ThrowIfOperationFailed_WithUpdateResultModifiedCountZeroANdMatchedZero_NotUpdatedException()
	{
		var updateResult =  Task.FromResult((UpdateResult)new FakeUpdateResult(0, 0));

		await updateResult.Invoking(x => x.ThrowIfOperationFailed())
			.Should()
			.ThrowAsync<NotUpdatedException>()
			.WithMessage("No updates or element not found.");
	}
	
	[Fact]
	public async Task ThrowIfOperationFailed_WithUpdateResultModifiedCountMoreThanZero()
	{
		var updateResult =  Task.FromResult((UpdateResult)new FakeUpdateResult(1, 1));

		await updateResult.Invoking(x => x.ThrowIfOperationFailed())
			.Should()
			.NotThrowAsync();
	}
	
	[Fact]
	public async Task ThrowIfOperationFailed_WithFoundEntity_Entity()
	{
		var sampleEntity = Task.FromResult(new FlightPlan() { AircraftIdentification = "test" });

		var result = await sampleEntity.ThrowIfOperationFailed();

		result.Should().BeEquivalentTo(new FlightPlan() { AircraftIdentification = "test" });
	}
	
	[Fact]
	public async Task ThrowIfOperationFailed_WithNotFoundEntity_NotFoundException()
	{
		FlightPlan sampleNullEntity = null;
		var sampleNullEntityTask = Task.FromResult(sampleNullEntity);

		await sampleNullEntityTask.Invoking(x => x.ThrowIfOperationFailed())
			.Should()
			.ThrowAsync<NotFoundException>()
			.WithMessage("Document not found.");
	}
}