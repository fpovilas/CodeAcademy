using GettingDataFromAPI.Model;

namespace GettingDataFromAPI.Repository.Interface
{
    public interface IWeatherForecastRepository
    {
        public bool SaveToDatabase(WeatherForecast weatherForecast);
    }
}
