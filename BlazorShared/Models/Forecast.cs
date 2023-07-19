using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;

public class Forecast
{
    public double TempF { get; private set; }
    public double TempC => (TempF - 32) * 0.556;

    public double FeelsTempF { get; private set; }
    public double FeelsTempC => (FeelsTempF - 32) * 0.556;

    public int? PrecipitationChance { get; private set; }

    public int Humidity { get; private set; }

    public double? MinTemp { get; private set; }
    public double? MaxTemp { get; private set; }

    public Forecast(double tempF, double feelsTempF, int? precipitationChance, int humidity, double? minTemp, double? maxTemp)
    {
        TempF = tempF;
        FeelsTempF = feelsTempF;
        PrecipitationChance = precipitationChance;
        Humidity = humidity;
        MinTemp = minTemp;
        MaxTemp = maxTemp;
    }

    public Forecast() { }
}
