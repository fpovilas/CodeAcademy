using GettingDataFromAPI.Context;
using GettingDataFromAPI.DTO;
using GettingDataFromAPI.Model;
using GettingDataFromAPI.Repository.Interface;

namespace GettingDataFromAPI.Repository
{
    public class WeatherForecastRepository(WeatherForecastContext context) : IWeatherForecastRepository
    {
        //public bool SaveToDatabase(WeatherForecastDTO weatherForecastDTO) // Nested If statment
        //{
        //    if(weatherForecastDTO is not null)
        //    {
        //        try
        //        {
        //            WeatherForecast weatherForecast = new();
        //            weatherForecast.ConvertFromDTO(weatherForecastDTO);
        //            context.WeatherForecasts.Add(weatherForecast);
        //            context.SaveChanges();
        //            return true;
        //        }
        //        catch
        //        {
        //            return false;
        //        }
        //    } else { return false; }
        //}

        public bool SaveToDatabase(WeatherForecast weatherForecast) // Inverted If statment (Avoids nesting)
        {
            if (weatherForecast is null)
            {
                return false;
            }

            try
            {
                context.WeatherForecasts.Add(weatherForecast);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
