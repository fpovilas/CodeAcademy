using Microsoft.Extensions.DependencyInjection;
using MultiProjectStructure.BusinessLogic.Service;
using MultiProjectStructure.BusinessLogic.Service.Interface;

namespace MultiProjectStructure.BusinessLogic.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection service)
        {
            service.AddScoped<IPhotoService, PhotoService>();
            return service;
        }
    }
}
