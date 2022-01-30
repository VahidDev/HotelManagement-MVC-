using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Constants.POCOConstants.WebsiteSectionConstants.AboutPageConstants;
using Hotel.Models.WebsiteSections.AboutPageSections;

namespace Hotel.DAL.Seeding.POCOGenerators.WebsiteSectionGenerators.AboutPageGenerators
{
    public static class AboutPageBannerGenerator
    {
        public static async Task GenerateAboutPageBannerAsync(this AppDbContext dbContext)
        {
            await dbContext.AboutPageBannerSections.AddAsync(new AboutPageBannerSection { 
            Image= AboutPageBannerConstants.Image,
            Description=AboutPageBannerConstants.Description,
            Title=AboutPageBannerConstants.Title
            });
        }
    }
}
