using Lifty_WebApp.Business.Interfaces;
using Lifty_WebApp.Business.Services;
using Lifty_WebApp.DataAccess;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Lifty_WebApp.Business
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBusinessLogicServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddEfRepositories(configuration.GetConnectionString("DefaultConnection"));

            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IServicingService, ServicingService>();

            return services;
        }
    }
}