using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Weather.API;

internal class TempRecord
{
    [JsonPropertyName("day")] public double DayTemp { get; set; }
    [JsonPropertyName("min")] public double? MinTemp { get; set; }
    [JsonPropertyName("max")] public double? MaxTemp { get; set; }
    [JsonPropertyName("night")] public double NightTemp { get; set; }
    [JsonPropertyName("eve")] public double EveningTemp { get; set; }
    [JsonPropertyName("morn")] public double MornTemp { get; set; }
}
