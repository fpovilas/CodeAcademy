using GettingDataFromAPI.Controllers;
using GettingDataFromAPI.DTO;
using GettingDataFromAPI.Extension.Interface;
using GettingDataFromAPI.Model;
using GettingDataFromAPI.Repository.Interface;
using Newtonsoft.Json;

namespace GettingDataFromAPI.Extension
{
    public class HttpClientExtension(HttpClient httpClient, IWeatherForecastRepository weatherForecastRepository, ILogger<WeatherForecastController> logger, IConfiguration configuration) : IHttpClientExtension
    {
        public async Task<WeatherForecast> GetWeatherForecast(string cityName)
        {
            try
            {
                string apiKey = configuration.GetValue<string>("ApiKey")!;
                string uri = $"https://weather.visualcrossing.com/VisualCrossingWebServices/rest/services/timeline/{cityName}/today?unitGroup=metric&key={apiKey}&contentType=json";

                logger.LogInformation($"ApiKey ({apiKey}) and URI initialized ({uri})");

                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(uri)
                };

                logger.LogInformation($"HTTP request crafted ({request})");

                var response = await httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                logger.LogInformation("Weather Forecast received successfully.");

                var body = await response.Content.ReadAsStringAsync();
                WeatherForecastDTO deserilizationCall = JsonConvert.DeserializeObject<WeatherForecastDTO>(body)!;

                logger.LogInformation("Converting from DTO.");

                WeatherForecast weatherForecast = new();
                weatherForecast.ConvertFromDTO(deserilizationCall);

                logger.LogInformation("Sending data to database.");

                if (weatherForecastRepository.SaveToDatabase(weatherForecast))
                {
                    logger.LogInformation("Data saved in DB.");
                }
                else { logger.LogError("Failed to save data in DB"); }

                return weatherForecast;
            }
            catch (Exception ex)
            {
                logger.LogError(ex.ToString());
                return new WeatherForecast();
            }
        }
    }
}
