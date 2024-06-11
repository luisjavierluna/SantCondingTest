using Core.Interfaces.Services;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCoreServiceCollection(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddTransient<IStoriesService, StoriesService>();
            services.AddTransient<IHackerNewsAPIService, HackerNewsAPIService>();

            return services;
        }
    }
}
