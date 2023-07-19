using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Weather.API;

internal class WeatherResponse
{
    [JsonPropertyName("lat")] public double Latitude { get; set; } = new double();
    [JsonPropertyName("lon")] public double Longitude { get; set; } = new double();
    [JsonPropertyName("timezone")] public string Timezone { get; set; } = String.Empty;
    [JsonPropertyName("timezone_offset")] public int TimezoneOffset { get; set; } = new int();
    [JsonPropertyName("current")] public CurrentWeather CurrentWeather { get; set; } = new CurrentWeather();
    [JsonPropertyName("hourly")] public List<HourlyForecast> HourlyForecasts { get; set; } = new List<HourlyForecast>();
    [JsonPropertyName("daily")] public List<DailyForecast> DailyForecasts { get; set;} = new List<DailyForecast>();
    [JsonPropertyName("alerts")] public List<Alerts> Alerts { get; set; } = new List<Alerts>();

    public override string ToString()
    {
        return $"{{ Latitude: {Latitude}, Longitude: {Longitude}, TimeZone: {Timezone} }}";
    }
}
