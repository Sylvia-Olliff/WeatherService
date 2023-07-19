using BlazorShared.Interfaces;
using BlazorShared.Models;

namespace BlazorAdmin.Services;

public class GeoLookupService : IGeoLookupService
{
    private readonly HttpService _httpService;
    private readonly ILogger<GeoLookupService> _logger;

    public GeoLookupService(HttpService httpService, ILogger<GeoLookupService> logger)
    {
        _httpService = httpService;
        _logger = logger;
    }

    private async Task<Location> Send(string uri)
    {
        var response = await _httpService.HttpGet<GeoLocationResponse>(uri);
        return response.Location;
    }

    public async Task<Location> GetLocationFromCity(GeoLookupCityRequest request)
    {
        return await Send($"api/geocoding/city-state?city={request.City}&state={request.StateCode}&country={request.CountryCode}");
    }

    public async Task<Location> GetLocationFromZip(GeoLookupZipRequest request)
    {
        return await Send($"api/geocoding/zipcode?zipcode={request.ZipCode}&country={request.CountryCode}");
    }

    public async Task<Location> GetLocationReverse(GeoLookupGeoRequest request)
    {
        return await Send($"api/geocoding/reverse?lat={request.Latitude}&lon={request.Longitude}");
    }
}
