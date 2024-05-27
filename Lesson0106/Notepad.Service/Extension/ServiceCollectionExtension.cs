using Microsoft.Extensions.DependencyInjection;
using Notepad.Service.Service;
using Notepad.Service.Service.Interface;

namespace Notepad.Service.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddNotepadService(this IServiceCollection services)
        {
            services.AddTransient<IJWTService, JWTService>();
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITagService, TagService>();
            services.AddScoped<INoteImageService, NoteImageService>();
            return services;
        }
    }
}
