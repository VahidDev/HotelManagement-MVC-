using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.DAL.Seeding
{
    public static class ApplicationBuilderSeeder
    {
        public async static Task Seed(this IApplicationBuilder builder)
        {
            using IServiceScope scope = builder.ApplicationServices.CreateScope();
            AppDbContext dbContext=scope.ServiceProvider
                .GetRequiredService<AppDbContext>();
            UserManager<User> userManager=scope.ServiceProvider
                .GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager=scope.ServiceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();
            DatabaseSeeder seeder = new(dbContext, userManager,roleManager);
            await seeder.Seed();
        }
    }
}
