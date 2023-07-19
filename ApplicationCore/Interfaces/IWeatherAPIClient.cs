using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces;

public interface IWeatherAPIClient
{
    Task<T> SendAsync<T>(string endpoint, string queryParams);
}
