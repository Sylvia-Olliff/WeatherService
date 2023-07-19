using ApplicationCore.Constants;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using Ardalis.GuardClauses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services;

public class WeatherAPIClient : IWeatherAPIClient
{
    private readonly IAppLogger<WeatherAPIClient> _logger;

    public WeatherAPIClient(IAppLogger<WeatherAPIClient> logger)
    {
        _logger = logger;
    }

    public async Task<T> SendAsync<T>(string endpoint, string queryParams)
    {
        Guard.Against.NullOrEmpty(queryParams);
        Guard.Against.NullOrEmpty(endpoint);

        using (HttpClient client = new())
        {
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.BaseAddress = new Uri(WeatherConstants.BASE_URL);

            _logger.LogInformation($"Sending request to {endpoint} with query: {queryParams}");

            HttpResponseMessage response = await client.GetAsync($"{endpoint}?{queryParams}");

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("Successful response received from Weather API");
                var item = await response.Content.ReadFromJsonAsync<T>();
                // var item = JsonConvert.DeserializeObject<T>(itemStr);

                // _logger.LogInformation("Response String: {response}", itemStr);
                _logger.LogInformation("Deserialized Response: {response}", item);
                return item;
            }
            else
            {
                _logger.LogError("ERROR received from Weather API", response);
                throw new WeatherServiceAPIException(response.ReasonPhrase ?? "UNKNOWN", response.StatusCode);
            }
        }
    }
}
