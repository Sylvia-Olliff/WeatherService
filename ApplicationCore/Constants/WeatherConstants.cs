using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Constants;

public class WeatherConstants
{
    public const string AUTH_KEY = "0b696542c0c49a027bd8b07cdfea6b5c";

    public const string UNITS = "Imperial";

    public const string BASE_URL = "https://api.openweathermap.org/";

    public const string WEATHER_ENDPOINT = "data/3.0/onecall";

    public const string GEOCODING_ENDPOINT = "geo/1.0/direct";

    public const string GEOCODING_ZIP_ENDPOINT = "geo/1.0/zip";

    public const string GEOCODING_REVERSE_ENDPOINT = "geo/1.0/reverse";
}
