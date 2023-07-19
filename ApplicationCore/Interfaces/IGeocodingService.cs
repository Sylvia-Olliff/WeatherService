using ApplicationCore.Entities.Weather;
using BlazorShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IGeocodingService
    {
        Task<Location> GetLocationFromCityStateAsync(Location location);

        Task<Location> GetLocationFromZipCodeAsync(Location location);

        Task<Location> GetLocationFromGeocodeAsync(Location location);
    }
}
