using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Constants.POCOConstants;
using Hotel.Models;

namespace Hotel.DAL.Seeding.POCOGenerators
{
    public static class LogoGenerator
    {
        public async static Task GenerateLogoAsync(this AppDbContext dbContext)
        {
            await dbContext.Logos.AddAsync(new Layout { Logo = DefaultLayoutConstants.Logo});
        }
    }
}
