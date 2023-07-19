using BlazorShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Interfaces;

public interface IWeatherReportService
{
    Task<WeatherData> GetWeatherData(GetWeatherDataRequest request);
}
