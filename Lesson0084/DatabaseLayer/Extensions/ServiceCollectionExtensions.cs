using DatabaseLayer.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseLayer.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterDataService(this IServiceCollection serviceCollection, IConfigurationManager configuration)
        {
            serviceCollection.AddDbContext<CarsContext>(db => db.UseSqlServer(configuration.GetConnectionString("Database")));

            return serviceCollection;
        }
    }
}
