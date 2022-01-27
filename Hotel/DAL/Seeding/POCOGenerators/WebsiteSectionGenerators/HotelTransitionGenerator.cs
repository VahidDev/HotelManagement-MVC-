using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Constants.POCOConstants.WebsiteSectionConstants;
using Hotel.Models.WebsiteSections;
using Hotel.Models.WebsiteSections.SubWebsiteSections;

namespace Hotel.DAL.Seeding.POCOGenerators
{
    public static class HotelTransitionGenerator
    {
        public static async Task GenerateHotelTransitionAsync(this AppDbContext dbContext)
        {
            await dbContext.HotelTransitionSections.AddAsync(
                new HotelTransitionSection
                {
                    Title = DefaultHotelTransitionConstants.Title,
                    Description = DefaultHotelTransitionConstants.Description
                });
            await dbContext.HotelTransitionSectionImages.AddRangeAsync(
                new HotelTransitionSectionImage { Image=DefaultHotelTransitionConstants.Image1},
                new HotelTransitionSectionImage { Image=DefaultHotelTransitionConstants.Image2},
                new HotelTransitionSectionImage { Image=DefaultHotelTransitionConstants.Image3},
                new HotelTransitionSectionImage { Image=DefaultHotelTransitionConstants.Image4},
                new HotelTransitionSectionImage { Image=DefaultHotelTransitionConstants.Image5},
                new HotelTransitionSectionImage { Image=DefaultHotelTransitionConstants.Image6}
                    );
        }
    }
}
