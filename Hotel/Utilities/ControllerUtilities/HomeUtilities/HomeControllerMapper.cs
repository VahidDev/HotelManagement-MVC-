using System.Linq;
using System.Threading.Tasks;
using Hotel.DAL;
using Hotel.ViewModels.HomePageViewModels;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Utilities.ControllerUtilities.HomeUtilities
{
    public static class HomeControllerMapper
    {
        public static async Task<HomeIndexViewModel> MapHomeIndexViewModelAsync(AppDbContext dbContext)
        {
            return new HomeIndexViewModel
            {
                HotelBannerSection = await dbContext.HotelBannerSections.FirstOrDefaultAsync(),
                Comments = await dbContext.Comments.Where(c => !c.IsDeleted).Include(c => c.Room)
            .Include(c => c.Rating).Take(4).ToListAsync(),
                Facilities = await dbContext.Facilities.Where(f => !f.IsDeleted).Take(4).ToListAsync(),
                HotelCommentSection = await dbContext.HotelCommentSections.FirstOrDefaultAsync(),
                HotelInfoSection = await dbContext.HotelInfoSections.FirstOrDefaultAsync(),
                HotelShowcaseSection = await dbContext.HotelShowcaseSections.FirstOrDefaultAsync(),
                HotelTransitionSection = await dbContext.HotelTransitionSections.FirstOrDefaultAsync(),
                HotelTransitionSectionImages = await dbContext.HotelTransitionSectionImages.ToListAsync(),
                Rooms = await dbContext.Rooms.Where(r => !r.IsDeleted).Include(r => r.RoomImages.Where(r => r.IsMain)).ToListAsync()
            };
        }
    }
}
