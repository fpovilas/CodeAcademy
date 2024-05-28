using FinalProject.Database.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProject.Database.Extension
{
    public static class DbCollectionExtension
    {
        public static IServiceCollection AddPRSDbService(this IServiceCollection services, string connString)
        {
            services.AddDbContext<PRSDbContext>
                (options => options.UseSqlServer(connString));
            return services;
        }
    }
}
