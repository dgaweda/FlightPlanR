using FlightPlanApi.Middleware;
using FlightPlanR.DataAccess;
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
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
// Add custom services to the container.
builder.Services.AddDataAccessServices(builder.Configuration);

var app = builder.Build();

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
app.MapControllers();

app.Run();