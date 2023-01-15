using System.Text.Json.Serialization;

namespace FlightPlanApi.Models;

public abstract class BaseEntity
{
    [JsonPropertyName("id")]
    public string Id { get; set; }
}