using GettingDataFromAPI.Model;

namespace GettingDataFromAPI.Extension.Interface
{
    public interface IHttpClientExtension
    {
        public Task<WeatherForecast> GetWeatherForecast(string cityName);
    }
}
