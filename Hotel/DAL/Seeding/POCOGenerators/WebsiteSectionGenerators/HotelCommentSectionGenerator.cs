using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Constants.POCOConstants.WebsiteSectionConstants;
using Hotel.Models.WebsiteSections;

namespace Hotel.DAL.Seeding.POCOGenerators.WebsiteSectionGenerators
{
    public static class HotelCommentSectionGenerator
    {
        public async static Task GenerateCommentSectionAsync(this AppDbContext dbContext)
        {
            await dbContext.AddAsync(new HotelCommentSection {
                    Title=DefaultHotelCommentSectionConstants.Title,
                    Description=DefaultHotelCommentSectionConstants.Description
                    });
        }
    }
}
