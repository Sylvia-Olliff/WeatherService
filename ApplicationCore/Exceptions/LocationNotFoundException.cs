using ApplicationCore.Entities.Weather;
using BlazorShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Exceptions;

public class LocationNotFoundException : Exception
{
    public LocationNotFoundException(Location location, Exception exception) : base($"Unable to find \"{location}\"!", exception) { }
    public LocationNotFoundException(Location location) : base($"Unable to find \"{location}\"!") { }
}
