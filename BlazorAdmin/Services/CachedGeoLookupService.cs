using Blazored.LocalStorage;
using BlazorShared.Interfaces;
using BlazorShared.Models;

namespace BlazorAdmin.Services;

public class CachedGeoLookupService : IGeoLookupService
{
    private readonly GeoLookupService _geoLookupService;
    private readonly ILocalStorageService _storageService;
    private ILogger<CachedGeoLookupService> _logger;

    private readonly string GEO_LOOKUP_KEY = "geolocations";

    public CachedGeoLookupService(GeoLookupService geoLookupService,
        ILocalStorageService storageService, 
        ILogger<CachedGeoLookupService> logger)
    {
        _geoLookupService = geoLookupService;
        _storageService = storageService;
        _logger = logger;
    }

    public async Task<Location> GetLocationFromCity(GeoLookupCityRequest request)
    {
        string key = $"{GEO_LOOKUP_KEY}-{request.City}-{request.StateCode}";
        var cacheEntry = await _storageService.GetItemAsync<CacheEntry<Location>>(key);
        if (cacheEntry != null) 
        {
            _logger.LogInformation("Loading location from storage...");
            return cacheEntry.Value;
        }
        
        var location = await _geoLookupService.GetLocationFromCity(request);
        var entry = new CacheEntry<Location>(location);
        await _storageService.SetItemAsync(key, entry);
        return location;
    }

    public async Task<Location> GetLocationFromZip(GeoLookupZipRequest request)
    {
        string key = $"{GEO_LOOKUP_KEY}-{request.ZipCode}-{request.CountryCode}";
        var cacheEntry = await _storageService.GetItemAsync<CacheEntry<Location>>(key);
        if (cacheEntry != null)
        {
            _logger.LogInformation("Loading location from storage...");
            return cacheEntry.Value;
        }

        var location = await _geoLookupService.GetLocationFromZip(request);
        var entry = new CacheEntry<Location>(location);
        await _storageService.SetItemAsync(key, entry);
        return location;
    }

    public async Task<Location> GetLocationReverse(GeoLookupGeoRequest request)
    {
        string key = $"{GEO_LOOKUP_KEY}-{(int)request.Latitude}-{(int)request.Longitude}";
        var cacheEntry = await _storageService.GetItemAsync<CacheEntry<Location>>(key);
        if (cacheEntry != null)
        {
            _logger.LogInformation("Loading location from storage...");
            return cacheEntry.Value;
        }

        var location = await _geoLookupService.GetLocationReverse(request);
        var entry = new CacheEntry<Location>(location);
        await _storageService.SetItemAsync(key, entry);
        return location;
    }

    public async void PurgeCache()
    {
        await _storageService.ClearAsync();
    }
}
