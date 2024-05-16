using Microsoft.Extensions.DependencyInjection;
using Notepad.Repository.Repository.Interface;
using Notepad.Repository.Repository;
using Notepad.Service.Service;
using Notepad.Service.Service.Interface;

namespace Notepad.Service.Extension
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddNotepadService(this IServiceCollection services)
        {
            services.AddScoped<INoteService, NoteService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITagService, TagService>();
            services.AddTransient<IJWTService, JWTService>();
            return services;
        }
    }
}
