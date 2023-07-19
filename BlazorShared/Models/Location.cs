using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorShared.Models;

public class Location
{
    public string? City { get; set; }
    public string? Country { get; set; }

    [DataType(DataType.PostalCode)] 
    public string? ZipCode { get; set; }
    public string? StateCode { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }

    public Location(string city, string country, string stateCode, double? latitude, double? longitude)
    {
        City = city;
        Country = country;
        StateCode = stateCode;
        Latitude = latitude;
        Longitude = longitude;
    }

    public Location(string city, string country, string stateCode)
    {
        City = city;
        Country = country;
        StateCode = stateCode;
    }

    public Location(double? latitude, double? longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public Location(string zipCode, string country)
    {
        ZipCode = zipCode;
        Country = country;
    }

    public Location() { }

    public override string ToString()
    {
        if (City != null)
        {
            return $"City: {City}, StateCode: {StateCode}, ZipCode: {ZipCode}, Country: {Country}";
        }
        else
        {
            return $"Longitude {Longitude}, Latitude: {Latitude}";
        }
    }
}
