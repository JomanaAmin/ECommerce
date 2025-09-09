using ECommerceApp.Data;
using ECommerceApp.Data.Interfaces;
using ECommerceApp.Data.Repositories;
using ECommerceApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Text;

namespace ECommerceApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // this is the replacement for IConfigurationRoot
            IConfiguration configuration = builder.Configuration;

            // this is the replacement for IHostingEnvironment
            IWebHostEnvironment env = builder.Environment;
            // Add services to the container.
            builder.Services.AddDbContext<AppDbContext>(options=> options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddControllersWithViews();
            builder.Services.AddTransient<IItemRepository, ItemRepository>();
            builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage(); //new
            app.UseStatusCodePages(); //new
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            DbInitializer.Seed(app.Services);

            app.Run();
        }
    }
}
