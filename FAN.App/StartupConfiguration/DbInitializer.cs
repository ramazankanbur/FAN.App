using FAN.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace FAN.App.StartupConfiguration
{
    public static class DbInitializer
    {
        public static void InitializeDb(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var dataContext = scope.ServiceProvider.GetRequiredService<FANContext>();
                dataContext.Database.Migrate();
            }
        }

        public static void AddDataLayer(this WebApplicationBuilder builder)
        {
            var connString = builder.Configuration.GetConnectionString("MSSqlConnection");
            builder.Services.AddDbContextPool<FANContext>(
                options => options.UseSqlServer(connString));
        }
    }
    }
 
