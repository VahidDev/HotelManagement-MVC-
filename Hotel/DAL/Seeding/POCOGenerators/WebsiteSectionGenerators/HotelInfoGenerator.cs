using System.Threading.Tasks;
using Hotel.Constants.POCOConstants;
using Hotel.Models.WebsiteSections;

namespace Hotel.DAL.Seeding.POCOGenerators
{
    public static class HotelInfoGenerator
    {
        public async static Task GenerateHotelInfoSectionAsync(this AppDbContext dbContext)
        {
            await dbContext.HotelInfoSections.AddAsync(
                new HotelInfoSection
                {
                    FirstImage=DefaultHotelInfoSectionConstants.FirstImage,
                    FirstImageTitle=DefaultHotelInfoSectionConstants.FirstImageTitle,
                    FirstImageDescription=DefaultHotelInfoSectionConstants.FirstImageDescription,
                    SecondImage=DefaultHotelInfoSectionConstants.SecondImage,
                    SecondImageTitle=DefaultHotelInfoSectionConstants.SecondImageTitle,
                    SecondImageDescription=DefaultHotelInfoSectionConstants.SecondImageDescription
                }
                );
        }
    }
}
