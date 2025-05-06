using Microsoft.EntityFrameworkCore;
using System;
using WebApplication1.DAL;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(opt => {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });


            var app = builder.Build();

            app.UseStaticFiles();

            app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
          );

            app.MapControllerRoute(
             name: "default",
             pattern: "{controller=Home}/{action=Index}"
             );


            app.Run();
        }
    }
}
