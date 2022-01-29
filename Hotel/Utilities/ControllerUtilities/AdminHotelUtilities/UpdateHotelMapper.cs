using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.DAL;
using Hotel.Models;
using Hotel.ViewModels.AdminViewModels.AdminHotelViewModels;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Utilities.ControllerUtilities.AdminHotelUtilities
{
    public static class UpdateHotelMapper
    {
        public async static Task<AdminHotelUpdateViewModel> MapAsync
            (AppDbContext dbContext,int id,Models.Hotel hotel)
        {
            AdminHotelUpdateViewModel model= new()
            {
                Name = hotel.Name,
                Address = hotel.Address,
                City = hotel.City,
                ShuttleServicePhone = hotel.ShuttleServicePhone,
                RestaurantPhone = hotel.RestaurantPhone,
                ReceptionPhone = hotel.ReceptionPhone,
                Description = hotel.Description,
                ImageName = hotel.Image,
                RatingId = hotel.Rating.Id,
                Rating=hotel.Rating,
                UserName= hotel.User.UserName,
                Ratings=await dbContext.Ratings.Where(r=>!r.IsDeleted).ToListAsync(),
                HotelId=hotel.Id
            };
            return model;
        }
    }
}
