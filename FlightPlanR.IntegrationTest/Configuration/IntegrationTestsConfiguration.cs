using FlightPlanApi.Common.Configuration;
using Microsoft.AspNetCore.Mvc.Testing;

namespace FlightPlanR.IntegrationTest.Configuration;

public class IntegrationTestsConfiguration : IClassFixture<WebApplicationFactory<Program>>
{
	protected readonly HttpClient HttpClient;
	private readonly string TestDbName = "flightPlanner_test";
	private readonly string ConnectionString = "mongodb://localhost:27017";
	
	public IntegrationTestsConfiguration(WebApplicationFactory<Program> factory)
	{
		HttpClient = factory.WithWebHostBuilder(builder =>
		{
			builder.ConfigureServices(services =>
			{
				var mongoConfigurationDescriptor =
					services.SingleOrDefault(service => service.ServiceType == typeof(MongoConfiguration));
				services.Remove(mongoConfigurationDescriptor);
				var mongoConfiguration = new MongoConfiguration()
				{
					DbName = TestDbName,
					ConnectionString = ConnectionString
				};
				services.AddSingleton(mongoConfiguration);
			});
		}).CreateClient();
	}
}