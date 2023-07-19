using BlazorAdmin.Services;
using BlazorShared.Interfaces;

namespace BlazorAdmin;

public static class ServicesConfiguration
{
    public static IServiceCollection AddBlazorServices(this IServiceCollection services)
    {
        services.AddScoped<IGeoLookupService, CachedGeoLookupService>();
        services.AddScoped<GeoLookupService>();
        services.AddScoped<IWeatherReportService, CachedWeatherReportService>();
        services.AddScoped<WeatherReportService>();

        return services;
    }
}
