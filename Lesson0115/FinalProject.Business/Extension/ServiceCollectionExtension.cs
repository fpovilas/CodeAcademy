using FinalProject.Business.Service;
using FinalProject.Business.Service.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace FinalProject.Business.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddPRSService(this IServiceCollection services)
        {
            services.AddTransient<IJWTService, JWTService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }
}
