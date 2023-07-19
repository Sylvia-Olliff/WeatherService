using ApplicationCore.Entities.Weather;

namespace PublicAPI.WeatherEndpoints;

public class WeatherReportResponse : BaseResponse
{
    public WeatherReportDto Report { get; set; } = new WeatherReportDto();
}
