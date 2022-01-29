using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.DAL;
using Hotel.Models;
using Hotel.ViewModels.AdminViewModels.AdminHotelViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Utilities.ControllerUtilities.AdminHotelUtilities
{
    public static class HotelMapper
    {
        public async static Task<Models.Hotel> MapAsync
            (AdminHotelCreateViewModel model,Guid guid,AppDbContext dbContext,User user) {
            Models.Hotel hotel = new()
            {
                Name = model.Name,
                Address = model.Address,
                City = model.City,
                ShuttleServicePhone=model.ShuttleServicePhone,
                RestaurantPhone=model.RestaurantPhone,
                ReceptionPhone=model.ReceptionPhone,
                Description=model.Description,
                Image=guid+model.ImageFile.FileName,
                Rating=await dbContext.Ratings.FirstOrDefaultAsync(r=>r.Id==model.RatingId&&!r.IsDeleted),
                User=user
            };
            return hotel;
    } 
        
    }
}

