using JsonNetConverters.UnixTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Weather.API;

internal class Alerts
{
    [JsonPropertyName("sender_name")] public string? SenderName { get; set; }
    [JsonPropertyName("event")] public string? EventName { get; set; }
    [JsonPropertyName("start")] public long? Start { get; set; }
    [JsonPropertyName("end")] public long? End { get; set; }
    [JsonPropertyName("description")] public string? Description { get; set; }
    [JsonPropertyName("tags")] public List<string?>? Tags { get; set; }
}
