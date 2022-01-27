using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Constants.POCOConstants;
using Hotel.Models;

namespace Hotel.DAL.Seeding.POCOGenerators
{
    public static class HotelBannerGenerator
    {
        public static async Task GenerateHotelBannerSectionAsync(this AppDbContext dbContext)
        {
            await dbContext.HotelBannerSections.AddAsync(new HotelBannerSection {
            BannerImage=DefaultHotelBannerConstants.HotelBannerImgae,
            Description=DefaultHotelBannerConstants.HotelBannerDescription,
            Title=DefaultHotelBannerConstants.HotelBannerTitle,
            });
        }
    }
}
