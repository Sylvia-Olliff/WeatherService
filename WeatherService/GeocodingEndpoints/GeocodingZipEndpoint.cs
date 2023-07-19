using ApplicationCore.Entities.Weather;
using ApplicationCore.Interfaces;
using Ardalis.GuardClauses;
using BlazorShared.Models;
using Microsoft.AspNetCore.Mvc;
using MinimalApi.Endpoint;

namespace PublicAPI.GeocodingEndpoints;

public class GeocodingZipEndpoint : IEndpoint<IResult, LocationRequest, IGeocodingService>
{
    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapGet("api/geocoding/zipcode",
            async (string? zipcode, string? country, [FromServices] IGeocodingService geoService) =>
            {
                return await HandleAsync(new LocationRequest(zipcode, country), geoService);
            })
            .Produces<GeocodingLocationResponse>()
            .WithTags("GeocodingEndpoints");
    }

    public async Task<IResult> HandleAsync(LocationRequest request, IGeocodingService geoService)
    {
        var response = new GeocodingLocationResponse(request.CorrelationId());

        Guard.Against.NullOrEmpty(request.CountryCode);
        Guard.Against.NullOrEmpty(request.ZipCode);

        var location = await geoService.GetLocationFromZipCodeAsync(new Location(request.ZipCode, request.CountryCode));

        response.Location = location;

        return Results.Ok(response);
    }
}
