using System;
using System.IO;
using Hotel.Constants;
using Hotel.DAL;
using Hotel.DAL.Seeding;
using Hotel.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;

namespace Hotel
{
    public class Startup
    {
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _env;
        public Startup(IConfiguration config, IWebHostEnvironment env)
        {
            _config = config;
            _env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddNewtonsoftJson(action=>
            action.SerializerSettings.ReferenceLoopHandling=ReferenceLoopHandling.Ignore
            );
            services.AddScoped<AppDbContext>();
            services.AddDbContext<AppDbContext>(options => {
                options.UseSqlServer(_config.GetConnectionString("Default"),
                    options =>{options.MigrationsAssembly(nameof(Hotel));}
                    );
            });
            services.AddIdentity<User, IdentityRole>(options=> {
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
            })
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<AppDbContext>();
            services.Configure<SecurityStampValidatorOptions>(options =>
                 options.ValidationInterval = TimeSpan.Zero);
            FileNameConstants.HotelImage = Path.Combine(_env.WebRootPath, "img","HOTEL");
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.Seed();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(configure => {
                configure.MapControllerRoute(
                 name: "areas",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
               );
                configure.MapControllerRoute("default",
                    "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
