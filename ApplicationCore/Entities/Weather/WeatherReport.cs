using Ardalis.GuardClauses;
using BlazorShared.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace ApplicationCore.Entities.Weather;

public class WeatherReport : BaseEntity
{
    public Location Location { get; private set; }
    
    public Forecast CurrentWeather { get; private set; }

    public Dictionary<DateTime, Forecast> HourlyForecast { get; private set; }
    public Dictionary<DateTime, Forecast> WeeklyForecast { get; private set; }


    public WeatherReport(Location location, Forecast currentWeather, Dictionary<DateTime, Forecast> hourlyForecast, Dictionary<DateTime, Forecast> weeklyForecast)
    {
        Location = location;
        CurrentWeather = currentWeather;
        HourlyForecast = hourlyForecast;
        WeeklyForecast = weeklyForecast;
    }

    public WeatherReport() 
    { 
        Location = new Location();
        CurrentWeather = new Forecast();
        HourlyForecast = new();
        WeeklyForecast = new();
    }

    public void UpdateCurrentWeather(Forecast current)
    {
        CurrentWeather = current;
    }

    public void UpdateLocation(Location location)
    {
        Location = location;
    }

    public void UpdateHourlyForecast(Dictionary<DateTime, Forecast> hourlyForecast)
    {
        HourlyForecast = hourlyForecast;
    }

    public void UpdateWeeklyForecast(Dictionary<DateTime, Forecast> weeklyForecast)
    {
        WeeklyForecast = weeklyForecast;
    }

    public class WeatherReportBuilder
    {
        private readonly WeatherReport _instance = new();

        public WeatherReportBuilder WithCurrentWeather(Forecast current)
        {
            _instance.UpdateCurrentWeather(current);
            return this;
        }

        public WeatherReportBuilder WithLocation(Location location)
        {
            _instance.UpdateLocation(location);
            return this;
        }

        public WeatherReportBuilder WithHourlyForecast(Dictionary<DateTime, Forecast> hourlyForecast)
        {
            _instance.UpdateHourlyForecast(hourlyForecast);
            return this;
        }

        public WeatherReportBuilder WithWeeklyForecast(Dictionary<DateTime, Forecast> weeklyForecast)
        {
            _instance.UpdateWeeklyForecast(weeklyForecast);
            return this;
        }

        public WeatherReport Build()
        {
            Guard.Against.Null(_instance.CurrentWeather);
            Guard.Against.Null(_instance.Location);
            Guard.Against.Null(_instance.HourlyForecast);
            Guard.Against.Null(_instance.WeeklyForecast);

            return _instance;
        }
    }
}
