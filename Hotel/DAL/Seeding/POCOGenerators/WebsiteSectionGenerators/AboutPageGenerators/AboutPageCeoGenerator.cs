using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Constants.POCOConstants.WebsiteSectionConstants.AboutPageConstants;
using Hotel.Models.WebsiteSections.AboutPageSections;

namespace Hotel.DAL.Seeding.POCOGenerators.WebsiteSectionGenerators.AboutPageGenerators
{
    public static class AboutPageCeoGenerator
    {
        public static async Task GenerateAboutPageCeoAsync(this AppDbContext dbContext)
        {
            await dbContext.AboutPageCeoSections.AddAsync(new AboutPageCeoSection{ 
                CeoImage=AboutPageCeoConstants.CeoImage,
                Description=AboutPageCeoConstants.Description,
                CeoName=AboutPageCeoConstants.CeoName,
            });
        }
    }
}
