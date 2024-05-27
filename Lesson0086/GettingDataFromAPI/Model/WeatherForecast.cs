using GettingDataFromAPI.DTO;
using System.Globalization;

namespace GettingDataFromAPI.Model
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        public string? City { get; set; }
        public float TemperatureC { get; set; }
        public DateOnly Date { get; set; }
        public string? Summary { get; set; }

        public void ConvertFromDTO(WeatherForecastDTO weatherForecastDTO)
        {
            City = weatherForecastDTO.address;
            TemperatureC = weatherForecastDTO.days[0].temp;
            Date = DateOnly.ParseExact(weatherForecastDTO.days[0].datetime!, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            Summary = weatherForecastDTO.description;
        }
    }
}
