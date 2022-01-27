using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Hotel.DAL.Seeding.POCOGenerators
{
    public static class RoleGenerator
    {
        public static async Task GenerateDefaultRolesAsync
            (this RoleManager<IdentityRole> roleManager)
        {
            await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            await roleManager.CreateAsync(new IdentityRole { Name = "Hotel" });
            await roleManager.CreateAsync(new IdentityRole { Name = "User" });
        }
    }
}
