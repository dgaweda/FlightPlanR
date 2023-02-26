using FlightPlanApi;
using FlightPlanApi.Middleware;
using FlightPlanR.Application;
using FlightPlanR.Infrastructure;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration.WriteTo.Console();
});
// Add Basic services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerConfig();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedOrigins", policyBuilder =>
    {
        policyBuilder.WithOrigins(builder.Configuration["AllowedOrigins"])
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

// Add custom services to the container.
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

var app = builder.Build();

// Configure the HTTP Request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/swagger/flightplanr/swagger.json", "FlightPlanR"));
}

app.UseCors("AllowedOrigins");

app.UseCustomeMiddlewares();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

namespace FlightPlanApi
{
    /// <summary>
    /// Created for testing purpose
    /// </summary>
    public partial class Program {}
} 