using FlightPlanApi.Middleware;
using FlightPlanR.DataAccess;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration
        .WriteTo.Console();
});
// Add Basic services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();

var app = builder.Build();
var configuration = app.Configuration;

// Add custom services to the container.
builder.Services.AddDataAccessServices(configuration);

// Configure the HTTP Request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(config =>
{
    config
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
});

app.UseMiddlewares();
app.UseHttpsRedirection();
app.UseAuthorization();

app.Run();