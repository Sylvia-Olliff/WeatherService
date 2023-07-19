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
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services;

public class GeocodingService : IGeocodingService
{
    private readonly IAppLogger<GeocodingService> _logger;
    private readonly IWeatherAPIClient _apiClient;

    public GeocodingService(IAppLogger<GeocodingService> logger, IWeatherAPIClient apiClient)
    {
        _logger = logger;
        _apiClient = apiClient;
    }

    public async Task<Location> GetLocationFromCityStateAsync(Location location)
    {
        Guard.Against.Null(location.City, nameof(location));
        Guard.Against.Null(location.StateCode, nameof(location));
        Guard.Against.Null(location.Country, nameof(location));
        Guard.Against.StateCode(location.StateCode);
        Guard.Against.CountryCode(location.Country);

        var query = $"q={location.City},{location.StateCode},{location.Country}&appid={WeatherConstants.AUTH_KEY}";

        var geoLocations = await _apiClient.SendAsync<List<GeocodingResponse>>(WeatherConstants.GEOCODING_ENDPOINT, query);

        if (!geoLocations.Any())
            throw new LocationNotFoundException(location);

        return new Location(geoLocations.First().Name, geoLocations.First().Country, geoLocations.First().State, geoLocations.First().Latitude, geoLocations.First().Longitude);
    }

    public async Task<Location> GetLocationFromGeocodeAsync(Location location)
    {
        Guard.Against.InvalidLocation(location);

        var query = $"lat={location.Latitude}&lon={location.Longitude}&appid={WeatherConstants.AUTH_KEY}";

        var geoLocations = await _apiClient.SendAsync<List<GeocodingResponse>>(WeatherConstants.GEOCODING_REVERSE_ENDPOINT, query);

        if (!geoLocations.Any())
            throw new LocationNotFoundException(location);

        return new Location(geoLocations.First().Name, geoLocations.First().Country, geoLocations.First().State, geoLocations.First().Latitude, geoLocations.First().Longitude);
    }

    public async Task<Location> GetLocationFromZipCodeAsync(Location location)
    {
        Guard.Against.Null(location.ZipCode, nameof(location));
        Guard.Against.Null(location.Country, nameof(location));
        Guard.Against.InvalidLocation(location);

        var query = $"zip={location.ZipCode},{location.Country}&appid={WeatherConstants.AUTH_KEY}";

        var geoLocation = await _apiClient.SendAsync<GeocodingResponse>(WeatherConstants.GEOCODING_ZIP_ENDPOINT, query);

        if (geoLocation == null)
            throw new LocationNotFoundException(location);

        return new Location(geoLocation.Name, geoLocation.Country, geoLocation.State, geoLocation.Latitude, geoLocation.Longitude);
    }
}
