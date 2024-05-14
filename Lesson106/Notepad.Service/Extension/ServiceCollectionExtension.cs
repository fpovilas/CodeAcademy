using Microsoft.Extensions.DependencyInjection;
using Notepad.Service.Service;
using Notepad.Service.Service.Interface;

namespace Notepad.Service.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddNotepadService(this IServiceCollection services)
        {
            services.AddScoped<INoteService, NoteService>();
            services.AddTransient<IJWTService, JWTService>();
            return services;
        }
    }
}
