using GettingDataFromAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace GettingDataFromAPI.Context
{
    public class WeatherForecastContext(DbContextOptions<WeatherForecastContext> options) : DbContext(options)
    {
        public virtual DbSet<WeatherForecast> WeatherForecasts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(@"Server=(localDB)\MSSQLLocalDB;Database=WeatherForecastDB;Trusted_Connection=True;");
            }
        }


    }
}
