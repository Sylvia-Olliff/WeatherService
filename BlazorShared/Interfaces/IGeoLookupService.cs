using BlazorShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Interfaces;

public interface IGeoLookupService
{
    Task<Location> GetLocationFromCity(GeoLookupCityRequest request);

    Task<Location> GetLocationFromZip(GeoLookupZipRequest request);

    Task<Location> GetLocationReverse(GeoLookupGeoRequest request);
}
