using BlazorAdmin.Helpers;
using BlazorAdmin.Services;
using BlazorShared.Interfaces;
using BlazorShared.Models;
using Microsoft.AspNetCore.Components;

namespace BlazorAdmin.Pages.WeatherServicePage;

public partial class MainWeatherPage : BlazorComponent
{
    [Inject]
    public IGeoLookupService GeoLookupService { get; set; }

    [Inject]
    public ToastService ToastService { get; set; }

    private Location CurrentLocation { get; set; } = new Location();

    private Location VerifiedLocation { get; set; } = new Location();

    private View ViewComponent { get; set; }

    private async void ResolveLocation()
    {
        if (CurrentLocation.Longitude.HasValue && CurrentLocation.Latitude.HasValue) 
        {
            VerifiedLocation = await GeoLookupService.GetLocationReverse(new GeoLookupGeoRequest
            {
                Longitude = CurrentLocation.Longitude.Value,
                Latitude = CurrentLocation.Latitude.Value
            });
            CurrentLocation = VerifiedLocation;
            ToastService.ShowToast("Successfully resolved location!", ToastLevel.Success);
        }
        else if (CurrentLocation.City != null && CurrentLocation.City.Length > 0)
        {
            if (CurrentLocation.Country == null || CurrentLocation.Country.Length == 0 || 
                CurrentLocation.StateCode == null || CurrentLocation.StateCode.Length == 0) { return; }

            VerifiedLocation = await GeoLookupService.GetLocationFromCity(new GeoLookupCityRequest 
            { 
                City = CurrentLocation.City,
                CountryCode = CurrentLocation.Country,
                StateCode = CurrentLocation.StateCode
            });
            CurrentLocation = VerifiedLocation;
            ToastService.ShowToast("Successfully resolved location!", ToastLevel.Success);
        } 
        else if (CurrentLocation.ZipCode != null && CurrentLocation.ZipCode.Length > 0)
        {
            if (CurrentLocation.Country == null || CurrentLocation.Country.Length == 0) { return; }

            VerifiedLocation = await GeoLookupService.GetLocationFromZip(new GeoLookupZipRequest 
            { 
                ZipCode = CurrentLocation.ZipCode,
                CountryCode = CurrentLocation.Country
            });
            CurrentLocation = VerifiedLocation;
            ToastService.ShowToast("Successfully resolved location!", ToastLevel.Success);
        } 
        else
        {
            ToastService.ShowToast("Unable to resolve location, check required fields", ToastLevel.Info);
        }

        StateHasChanged();
    }

    private async Task ViewClick()
    {
        if (VerifiedLocation.Latitude == null || VerifiedLocation.Longitude == null) {  return; }
        await ViewComponent.Open(VerifiedLocation);
    }
}
