using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.DAL;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Utilities.ControllerUtilities
{
    public static class LogoAdder
    {
        public async static Task<string> GetLogoAsync(AppDbContext dbContext)
        {
            return (await dbContext.Logos.FirstOrDefaultAsync()).Logo;
        }
    }
}
