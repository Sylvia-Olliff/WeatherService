using ApplicationCore.Entities.Weather;
using ApplicationCore.Interfaces;
using Ardalis.GuardClauses;
using BlazorShared.Models;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Endpoint;
using PublicAPI.GeocodingEndpoints;

namespace PublicAPI.WeatherEndpoints;

public class WeatherReportEndpoint : IEndpoint<IResult, LocationRequest, IWeatherService, IGeocodingService>
{
    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/weather/report",
            async (double? lat, double? lon, [FromServices] IWeatherService weatherService, [FromServices] IGeocodingService geocodingService) =>
            {
                return await HandleAsync(new LocationRequest(lat, lon), weatherService, geocodingService);
            })
            .Produces<WeatherReportResponse>()
            .WithTags("WeatherEndpoints");
    }

    public async Task<IResult> HandleAsync(LocationRequest request, IWeatherService weatherService, IGeocodingService geocodingService)
    {
        var response = new WeatherReportResponse();

        Guard.Against.Null(request.Longitude, nameof(request.Longitude));
        Guard.Against.Null(request.Latitude, nameof(request.Latitude));

        var report = await weatherService.GetWeatherReportAsync(new Location(request.Latitude, request.Longitude));

        var location = await geocodingService.GetLocationFromGeocodeAsync(report.Location);

        var dto = new WeatherReportDto
        {
            Location = location,
            CurrentWeather = report.CurrentWeather,
            WeeklyForecast = report.WeeklyForecast,
            HourlyForecast = report.HourlyForecast
        };

        response.Report = dto;
        return Results.Ok(response);
    }
}
