using JsonNetConverters.UnixTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationCore.Entities.Weather.API;

internal class DailyForecast
{
    [JsonPropertyName("dt")] public long TimeStamp { get; set; } = new();
    [JsonPropertyName("sunrise")] public long Sunrise { get; set; } = new();
    [JsonPropertyName("sunset")] public long Sunset { get; set; } = new();
    [JsonPropertyName("moonrise")] public long Moonrise { get; set; } = new();
    [JsonPropertyName("moonset")] public long Moonset { get; set; } = new();
    [JsonPropertyName("moon_phase")] public double Moonphase { get; set; } = new double();
    [JsonPropertyName("temp")] public TempRecord Temperature { get; set; } = new TempRecord();
    [JsonPropertyName("feels_like")] public TempRecord FeelsLike { get; set; } = new TempRecord();
    [JsonPropertyName("pressure")] public int Pressure { get; set; } = new int();
    [JsonPropertyName("humidity")] public int Humidity { get; set; } = new int();
    [JsonPropertyName("dew_point")] public double DewPoint { get; set; } = new double();
    [JsonPropertyName("wind_speed")] public double WindSpeed { get; set; } = new double();
    [JsonPropertyName("wind_deg")] public int WindDirection { get; set; } = new int();
    [JsonPropertyName("wind_gust")] public double WindGustSpeed { get; set; } = new double();
    [JsonPropertyName("weather")] public List<WeatherModifier> WeatherModifiersList { get; set; } = new List<WeatherModifier>();
    [JsonPropertyName("clouds")] public int CloudsPercentage { get; set; } = new int();
    [JsonPropertyName("pop")] public double RainChance { get; set; } = new double();
    [JsonPropertyName("rain")] public double RainDepth { get; set; } = new double();
    [JsonPropertyName("uvi")] public double UVIndex { get; set; } = new double();
}
