using GettingDataFromAPI.Extension.Interface;
using GettingDataFromAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace GettingDataFromAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController(IHttpClientExtension httpClientExtension) : ControllerBase
    {
        [HttpGet(Name = "GetWeatherForecast")]
        public Task<WeatherForecast> Get(string cityName) => httpClientExtension.GetWeatherForecast(cityName);
    }
}
