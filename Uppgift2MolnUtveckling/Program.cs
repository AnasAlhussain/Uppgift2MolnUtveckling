using Microsoft.EntityFrameworkCore;
using System;
using Uppgift2MolnUtveckling.Models;

namespace Uppgift2MolnUtveckling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            //Sql provider
            builder.Services.AddDbContext<AppDB>(options =>
            options.UseSqlServer(builder.Configuration.
            GetConnectionString("Default"),sqlServerOptionsAction:sqlOptions =>
            {
                sqlOptions.EnableRetryOnFailure(
                    maxRetryCount:10,
                    maxRetryDelay:TimeSpan.FromSeconds(5), 
                    errorNumbersToAdd:null );
            }));

            

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

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
