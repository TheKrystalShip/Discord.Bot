using Microsoft.Extensions.DependencyInjection;

namespace TheKrystalShip.Discord
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddManagers(this IServiceCollection services)
        {
            services.AddSingleton<EventManager>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddSingleton<GreetingService>();

            return services;
        }

        public static IServiceCollection AddTools(this IServiceCollection services)
        {
            services.AddSingleton<Tools>();

            return services;
        }
    }
}
