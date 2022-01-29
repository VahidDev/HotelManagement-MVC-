using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.ViewModels.AdminViewModels.AdminHotelViewModels;

namespace Hotel.Utilities.ControllerUtilities.AdminHotelUtilities
{
    public static class HotelMapper
    {
        public static void MapHotel(AdminHotelUpdateViewModel model, Models.Hotel hotel)
        {
            hotel.Name = model.Name;
            hotel.Address = model.Address;
            hotel.City = model.City;
            hotel.ShuttleServicePhone = model.ShuttleServicePhone;
            hotel.RestaurantPhone = model.RestaurantPhone;
            hotel.ReceptionPhone = model.ReceptionPhone;
            hotel.Description = model.Description;
            hotel.Image = model.ImageName;
            hotel.Rating = model.Rating;
        }
    }
}
