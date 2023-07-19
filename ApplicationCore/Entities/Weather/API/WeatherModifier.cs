using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Weather.API;

internal class WeatherModifier : BaseEntity
{
    [JsonPropertyName("main")] public string Main { get; set; } = String.Empty;

    [JsonPropertyName("description")] public string Description { get; set; } = String.Empty;

    [JsonPropertyName("icon")] public string IconCode { get; set; } = String.Empty;
}
