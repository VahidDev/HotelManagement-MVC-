using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Constants.POCOConstants.WebsiteSectionConstants;
using Hotel.Models.WebsiteSections;

namespace Hotel.DAL.Seeding.POCOGenerators.WebsiteSectionGenerators
{
    public static class HotelPageBannerGenerator
    {
        public static async Task GenerateHotelPageBannerAsync(this AppDbContext dbContext)
        {
            await dbContext.HotelPageBannerSections.AddAsync(
                new HotelPageBannerSection { 
                    Image=DefaultHotelPageBannerConstants.Image,
                    Title=DefaultHotelPageBannerConstants.Title,
                    Description=DefaultHotelPageBannerConstants.Description
                });
        }
    }
}
