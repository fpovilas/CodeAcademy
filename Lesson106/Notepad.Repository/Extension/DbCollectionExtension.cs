using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Notepad.Repository.Database;
using Notepad.Repository.Repository;
using Notepad.Repository.Repository.Interface;

namespace Notepad.Repository.Extension
{
    public static class DbCollectionExtension
    {
        public static IServiceCollection AddNotepadDbService(this IServiceCollection services, string connString)
        {
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddDbContext<NotepadDbContext>
                (options => options.UseSqlServer(connString));
            return services;
        }
    }
}
