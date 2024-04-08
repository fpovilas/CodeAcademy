
using GettingDataFromAPI.Context;
using GettingDataFromAPI.Extension;
using GettingDataFromAPI.Extension.Interface;
using GettingDataFromAPI.Repository;
using GettingDataFromAPI.Repository.Interface;

namespace GettingDataFromAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register DI
            builder.Services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

            // Register HTTP client
            builder.Services.AddHttpClient<IHttpClientExtension, HttpClientExtension>();

            // Register Database dependecy
            builder.Services.AddDbContext<WeatherForecastContext>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
