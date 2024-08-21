using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace FAN.App.StartupConfiguration
{
    public static class ConfigurationRepo
    {
        public static void AddConfigurations(this IServiceCollection services)
        {
            services.AddSignalR();
            services.AddDistributedMemoryCache();

            services.AddStackExchangeRedisCache(o =>
            {
                o.Configuration = "localhost:6379";
                o.InstanceName = "FANAPP";
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30); 
                options.Cookie.HttpOnly = false;  
                options.Cookie.IsEssential = true;  
            });


            services.AddHttpContextAccessor();

        }

    }
}
