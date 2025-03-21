using Eshop.Attributes;
using Eshop.Database;
using Eshop.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Eshop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

			string connectionString = builder.Configuration.GetConnectionString("MySQL")
				?? throw new InvalidOperationException("MySQL connection string is not provided");

			builder.Services.AddDbContext<DatabaseContext>(options =>
				options.UseMySQL(connectionString)
			);
            
            IntegrityHelper.Start(builder.Configuration,builder.Environment);
            

			builder.Services.AddScoped<ImportEntitiesAttribute>();

			builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=MainPage}/{action=Index}/{id?}");

       
            
            app.Run();
        }
    }
}
