using ApplicationCore.Entities.Weather;
using ApplicationCore.Interfaces;
using Ardalis.GuardClauses;
using BlazorShared.Models;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Endpoint;

namespace PublicAPI.GeocodingEndpoints;

public class GeocodingCityEndpoint : IEndpoint<IResult, LocationRequest, IGeocodingService>
{
    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/geocoding/city-state",
            async (string? city, string? state, string? country, [FromServices] IGeocodingService geoService) =>
            {
                return await HandleAsync(new LocationRequest(city, state, country), geoService);
            })
            .Produces<GeocodingLocationResponse>()
            .WithTags("GeocodingEndpoints");
    }

    public async Task<IResult> HandleAsync(LocationRequest request, IGeocodingService geoService)
    {
        var response = new GeocodingLocationResponse(request.CorrelationId());

        Guard.Against.NullOrEmpty(request.CountryCode);
        Guard.Against.NullOrEmpty(request.StateCode);
        Guard.Against.NullOrEmpty(request.CityName);

        var location = await geoService.GetLocationFromCityStateAsync(new Location(request.CityName, request.CountryCode, request.StateCode));

        response.Location = location;

        return Results.Ok(response);
    }
}
