using FAN.App.StartupConfiguration;

namespace FAN.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAppServices();
            builder.Services.AddConfigurations();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.AddDataLayer();

            var app = builder.Build();

            DbInitializer.InitializeDb(app);

            app.UseSession();


    
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
