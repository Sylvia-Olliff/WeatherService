using ApplicationCore.Entities.Weather;
using BlazorShared.Models;

namespace PublicAPI.WeatherEndpoints;

public class WeatherReportDto
{
    public Location Location { get; set; } = new();
    public Forecast CurrentWeather { get; set; } = new();
    public Dictionary<DateTime, Forecast> HourlyForecast { get; set; } = new();
    public Dictionary<DateTime, Forecast> WeeklyForecast { get; set; } = new();
}
