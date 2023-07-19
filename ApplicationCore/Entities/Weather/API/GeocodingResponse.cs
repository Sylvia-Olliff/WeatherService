using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Weather.API;

internal class GeocodingResponse
{
    [JsonPropertyName("name")] public string Name { get; set; } = string.Empty;
    [JsonPropertyName("lat")] public double Latitude { get; set; } = new double();
    [JsonPropertyName("lon")] public double Longitude { get; set; } = new double();
    [JsonPropertyName("country")] public string Country { get; set; } = string.Empty;
    [JsonPropertyName("state")] public string State { get; set; } = string.Empty;
}
