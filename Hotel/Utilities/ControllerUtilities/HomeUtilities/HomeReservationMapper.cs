using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.DAL;
using Hotel.ViewModels.HomePageViewModels;

namespace Hotel.Utilities.ControllerUtilities.HomeUtilities
{
    public static class HomeReservationMapper
    {
        public static async Task<HomeIndexViewModel> MapHomeReservationModelAsync
            (HomeIndexViewModel model,AppDbContext dbContext)
        {
            HomeIndexViewModel homeModel = await HomeControllerMapper.
                MapHomeIndexViewModelAsync(dbContext);
            homeModel.AdultCount = model.AdultCount;
            homeModel.ChildCount = model.ChildCount;
            homeModel.ReservationStart = model.ReservationStart;
            homeModel.ReservationEnd = model.ReservationEnd;
            return homeModel;
        }
    }
}
