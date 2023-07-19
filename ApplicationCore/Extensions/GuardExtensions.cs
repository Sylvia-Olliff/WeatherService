using ApplicationCore.Entities.Weather;
using ApplicationCore.Exceptions;
using Ardalis.GuardClauses;
using BlazorShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Extensions;

public static class LocationGuards
{
    public static void CountryCode(this IGuardClause guardClause, string countryCode)
    {
        if (countryCode.Length != 2)
            throw new InvalidLocationParameterException("Country Code must be exactly 2 characters");
    }

    public static void StateCode(this IGuardClause guardClause, string stateCode)
    {
        if (stateCode.Length != 2)
            throw new InvalidLocationParameterException("State Code must be exactly 2 characters");
    }

    public static void InvalidLocation(this IGuardClause guardClause, Location location)
    {
        if (location.Latitude != null || location.Longitude != null)
        {
            if (!(location.Latitude.HasValue && location.Longitude.HasValue))
                throw new InvalidLocationParameterException("If Longitude or Latitude has a value, the other must also have a value");

        }

        if (location.City != null && location.City.Length > 0)
        {
            if (location.StateCode == null || location.StateCode.Length == 0)
                throw new InvalidLocationParameterException("If City is defined, a State code must also be defined");

            if (location.Country == null || location.Country.Length == 0)
                throw new InvalidLocationParameterException("If City is defined, a Coutry code must also be defined");
        }

        if (location.ZipCode != null && location.ZipCode.Length > 0)
        {
            if (location.Country == null || location.Country.Length == 0)
                throw new InvalidLocationParameterException("If ZipCode is defined, a Coutry code must also be defined");
        }
    }
}
