namespace PublicAPI;

public class LocationRequest : BaseRequest
{
    public string? CityName { get; set; }
    public string? StateCode { get; set; }
    public string? CountryCode { get; set; }
    public string? ZipCode { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public LocationRequest(string? cityName, string? stateCode, string? countryCode, string? zipCode, double? latitude, double? longitude) : this(cityName, stateCode, countryCode)
    {
        ZipCode = zipCode;
        Latitude = latitude;
        Longitude = longitude;
    }

    public LocationRequest(string? cityName, string? stateCode, string? countryCode)
    {
        CityName = cityName;
        StateCode = stateCode;
        CountryCode = countryCode;
    }

    public LocationRequest(double? latitude, double? longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public LocationRequest(string? zipCode, string? countryCode)
    {
        ZipCode = zipCode;
        CountryCode = countryCode;
    }

    public LocationRequest() { }
}
