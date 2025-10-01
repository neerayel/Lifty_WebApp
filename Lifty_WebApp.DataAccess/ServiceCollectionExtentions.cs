using Lifty_WebApp.DataAccess.Interfaces;
using Lifty_WebApp.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lifty_WebApp.DataAccess
{
    public static class ServiceCollectionExtensions
    {
        private static IServiceCollection AddDbContext(this IServiceCollection services, string sqlConnectionString)
        {
            services.AddDbContextPool<DataContext>(options => options.UseSqlServer(sqlConnectionString));

            return services;
        }

        public static IServiceCollection AddEfRepositories(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext(connectionString);

            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IServicingRepository, ServicingRepository>();

            return services;
        }
    }
}
