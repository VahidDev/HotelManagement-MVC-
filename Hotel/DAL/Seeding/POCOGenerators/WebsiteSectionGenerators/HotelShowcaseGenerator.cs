using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Constants.POCOConstants.WebsiteSectionConstants;
using Hotel.Models.WebsiteSections;

namespace Hotel.DAL.Seeding.POCOGenerators.WebsiteSectionGenerators
{
    public static class HotelShowcaseGenerator
    {
        public async static Task GenerateHotelShowCaseAsync(this AppDbContext dbContext)
        {
            await dbContext.HotelShowcaseSections.AddAsync(
                new HotelShowcaseSection
                {
                    Title = DefaultHotelShowcaseConstants.Title,
                    Description=DefaultHotelShowcaseConstants.Description
                });
        }
    }
}
