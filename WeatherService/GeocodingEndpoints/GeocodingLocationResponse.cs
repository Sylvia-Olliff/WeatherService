using ApplicationCore.Entities.Weather;
using BlazorShared.Models;

namespace PublicAPI.GeocodingEndpoints;

public class GeocodingLocationResponse : BaseResponse
{
    public GeocodingLocationResponse(Guid correlationId) : base(correlationId)
    {
    }

    public GeocodingLocationResponse() { }

    public Location Location { get; set; } = new Location();
}
