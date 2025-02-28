using DraftLabOne.Application.Features.NoteFolder.CreateNote;
using DraftLabOne.Application.Interfaces.DataAccess;
using DraftLabOne.Infrastructure.DbContexts;
using DraftLabOne.Infrastructure.Providers;
using DraftLabOne.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DraftLabOne.Infrastructure
{
    public static class DependencyRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
                                                            IConfiguration configuration)
        {
            services.AddDataStorages(configuration);
            services.AddRepositories();
            services.AddInterceptors();
            // services.AddQueries();
            return services;
        }


        private static IServiceCollection AddDataStorages(this IServiceCollection services,
                                                              IConfiguration configuration)
        {
            services.AddScoped<ITransaction, Transaction>();
            services.AddScoped<NotesWriteDbContext>();
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<INoteRepository, NoteRepository>();

            return services;
        }

        private static IServiceCollection AddInterceptors(this IServiceCollection services)
        {
          //  services.AddSingleton<DateInterceptor>();

            return services;
        }

      
    }
}
