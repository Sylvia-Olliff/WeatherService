using BlazorShared.Interfaces;
using BlazorShared.Models;

namespace BlazorAdmin.Services;

public class WeatherReportService : IWeatherReportService
{
    private readonly HttpService _httpService;
    private readonly ILogger<WeatherReportService> _logger;

    public WeatherReportService(HttpService httpService, ILogger<WeatherReportService> logger)
    {
        _httpService = httpService;
        _logger = logger;
    }

    public async Task<WeatherData> GetWeatherData(GetWeatherDataRequest request)
    {
        var response = await _httpService.HttpGet<WeatherDataResponse>($"api/weather/report?lat={request.Latitude}&lon={request.Longitude}");
        return response.Report;
    }
}
