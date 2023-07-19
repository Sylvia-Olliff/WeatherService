using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Exceptions;

public class WeatherServiceAPIException : Exception
{
    public WeatherServiceAPIException(string message, HttpStatusCode statusCode) : base($"API ERROR: Status Code: {statusCode}. {message}") { }
}
