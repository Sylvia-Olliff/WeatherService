using ApplicationCore.Constants;
using ApplicationCore.Entities.Weather;
using ApplicationCore.Entities.Weather.API;
using ApplicationCore.Exceptions;
using ApplicationCore.Extensions;
using ApplicationCore.Interfaces;
using Ardalis.GuardClauses;
using BlazorShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services;

public class WeatherService : IWeatherService
{
    private readonly IAppLogger<WeatherService> _logger;
    private readonly IWeatherAPIClient _weatherAPIClient;

    public WeatherService(IAppLogger<WeatherService> logger, IWeatherAPIClient weatherAPIClient)
    {
        _logger = logger;
        _weatherAPIClient = weatherAPIClient;
    }

    private static string BuildWeatherQueryParams(Location location)
    {
        return $"lat={location.Latitude}&lon={location.Longitude}&exclude=minutely&units={WeatherConstants.UNITS}&appid={WeatherConstants.AUTH_KEY}";
    }

    private static WeatherReport GenerateReport(Location location, WeatherResponse response)
    {
        var builder = new WeatherReport.WeatherReportBuilder();

        Dictionary<DateTime, Forecast> hourlyForecast = new();
        Dictionary<DateTime, Forecast> weeklyForecast = new();

        DateTime epoch = new(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);

        response.HourlyForecasts.ForEach(forecast =>
        {
            hourlyForecast.Add(epoch.AddSeconds(forecast.TimeStamp), new Forecast(forecast.Temperature, forecast.FeelsLike, (int)((double)forecast.PrecipitationChance * 100), forecast.Humidity, null, null));
        });

        response.DailyForecasts.ForEach(forecast =>
        {
            weeklyForecast.Add(epoch.AddSeconds(forecast.TimeStamp), new Forecast(forecast.Temperature.DayTemp, forecast.FeelsLike.DayTemp, (int)((double)forecast.RainChance * 100), 
                forecast.Humidity, forecast.Temperature.MinTemp, forecast.Temperature.MaxTemp));
        });

        return builder
            .WithLocation(location)
            .WithCurrentWeather(new Forecast(response.CurrentWeather.Temperature, response.CurrentWeather.FeelsLike, null, response.CurrentWeather.Humidity, null, null))
            .WithHourlyForecast(hourlyForecast)
            .WithWeeklyForecast(weeklyForecast)
            .Build();
    }

    public async Task<WeatherReport> GetWeatherReportAsync(Location location)
    {
        Guard.Against.Null(location.Latitude, nameof(location));
        Guard.Against.Null(location.Longitude, nameof(location));

        try
        {
            var weatherResponse = await _weatherAPIClient.SendAsync<WeatherResponse>(WeatherConstants.WEATHER_ENDPOINT, BuildWeatherQueryParams(location));

            return GenerateReport(location, weatherResponse);
        } 
        catch(Exception e) 
        {
            _logger.LogError("Error while building weather report!", e);
            throw;
        }
    }
}
