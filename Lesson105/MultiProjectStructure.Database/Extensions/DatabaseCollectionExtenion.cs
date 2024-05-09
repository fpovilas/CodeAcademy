using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MultiProjectStructure.Database.Migrations.Context;
using MultiProjectStructure.Database.Repository;
using MultiProjectStructure.Database.Repository.Interface;

namespace MultiProjectStructure.Database.Extensions
{
    public static class DatabaseCollectionExtenion
    {
        public static IServiceCollection AddDatabaseService(this IServiceCollection services, string connectionString)
        {
            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddDbContext<ImageDbContext>(options
                                                    => options.UseSqlServer(connectionString));
            return services;
        }
    }
}
