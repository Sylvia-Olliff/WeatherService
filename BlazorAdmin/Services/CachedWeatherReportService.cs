using Blazored.LocalStorage;
using BlazorShared.Interfaces;
using BlazorShared.Models;

namespace BlazorAdmin.Services;

public class CachedWeatherReportService : IWeatherReportService
{
    private readonly ILocalStorageService _localStorageService;
    private readonly WeatherReportService _weatherReportService;
    private ILogger<CachedWeatherReportService> _logger;

    private readonly string WEATHER_REPORT_KEY = "weather-reports";

    public CachedWeatherReportService(ILocalStorageService localStorageService, 
        WeatherReportService weatherReportService, 
        ILogger<CachedWeatherReportService> logger)
    {
        _localStorageService = localStorageService;
        _weatherReportService = weatherReportService;
        _logger = logger;
    }

    public async Task<WeatherData> GetWeatherData(GetWeatherDataRequest request)
    {
        string key = $"{WEATHER_REPORT_KEY}_{(int)request.Latitude}-{(int)request.Longitude}";
        var cacheEntry = await _localStorageService.GetItemAsync<CacheEntry<WeatherData>>(key);
        if (cacheEntry != null)
        {
            _logger.LogInformation("Loading weather report from local storage");
            if (cacheEntry.DateCreated.AddMinutes(5) > DateTime.UtcNow)
            {
                return cacheEntry.Value;
            }
            else
            {
                _logger.LogInformation("Removing old cache entry {key} from local storage", key);
                await _localStorageService.RemoveItemAsync(key);
            }
        }

        var weatherReport = await _weatherReportService.GetWeatherData(request);
        var entry = new CacheEntry<WeatherData>(weatherReport);
        await _localStorageService.SetItemAsync(key, entry);
        return weatherReport;
    }
}
