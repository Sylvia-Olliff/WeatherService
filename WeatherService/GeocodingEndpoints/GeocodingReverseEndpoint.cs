using ApplicationCore.Entities.Weather;
using ApplicationCore.Interfaces;
using Ardalis.GuardClauses;
using BlazorShared.Models;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Endpoint;

namespace PublicAPI.GeocodingEndpoints;

public class GeocodingReverseEndpoint : IEndpoint<IResult, LocationRequest, IGeocodingService>
{
    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/geocoding/reverse",
            async (double? lat, double? lon, [FromServices] IGeocodingService geoService) =>
            {
                return await HandleAsync(new LocationRequest(lat, lon), geoService);
            })
            .Produces<GeocodingLocationResponse>()
            .WithTags("GeocodingEndpoints");
    }

    public async Task<IResult> HandleAsync(LocationRequest request, IGeocodingService geoService)
    {
        var response = new GeocodingLocationResponse(request.CorrelationId());

        Guard.Against.Null(request.Latitude);
        Guard.Against.Null(request.Longitude);

        var location = await geoService.GetLocationFromGeocodeAsync(new Location(request.Latitude, request.Longitude));

        response.Location = location;

        return Results.Ok(response);
    }
}
