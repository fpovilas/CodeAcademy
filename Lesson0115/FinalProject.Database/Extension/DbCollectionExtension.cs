using FinalProject.Database.Database;
using FinalProject.Database.Repository;
using FinalProject.Database.Repository.Interface;
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
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
