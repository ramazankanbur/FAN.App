using FAN.App.Session;

namespace FAN.App.StartupConfiguration
{
    internal static class ServiceExtensions
    {
        public static void AddAppServices(this IServiceCollection services)
        {
            services.AddScoped<ISessionService, SessionService>();
        }
    }
}
