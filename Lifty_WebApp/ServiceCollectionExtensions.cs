using Lifty_WebApp.DataAccess.Interfaces;
using Lifty_WebApp.DataAccess.Repositories;
using Microsoft.AspNetCore.Http.Features;

namespace LX.TestPad.DataAccess
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IStoredDataRepository, StoredDataRepository>();
            services.AddScoped<IImageRepository, ImageRepository>();

            return services;
        }

        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.Configure<FormOptions>(options =>
            {
                // Set the limit to 50 MB
                options.MultipartBodyLengthLimit = 52428800;
            });

            return services;
        }
    }
}
