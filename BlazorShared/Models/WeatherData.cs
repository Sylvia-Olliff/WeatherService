using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;

public class WeatherData
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Location field is required")]
    public Location Location { get; set; }

    [Required(ErrorMessage = "Current Forecast is required")]
    public Forecast CurrentForecast { get; set; }

    public Dictionary<DateTime, Forecast> HourlyForecast { get; set; } = new();
    public Dictionary<DateTime, Forecast> WeeklyForecast { get; set; } = new();
}
