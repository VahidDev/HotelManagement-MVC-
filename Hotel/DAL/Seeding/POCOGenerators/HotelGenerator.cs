using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Constants.POCOConstants;
using Hotel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Hotel.DAL.Seeding.POCOGenerators
{
    public static class HotelGenerator
    {
        public static async Task GenerateHotelAsync(this AppDbContext dbContext,UserManager<User>userManager)
        {
            await dbContext.Hotels.AddRangeAsync(
                new Models.Hotel
                {
                    Name = DefaultHotelConstants.HotelAName,
                    Description = DefaultHotelConstants.HotelADescription,
                    Address = DefaultHotelConstants.HotelAAdress,
                    City = DefaultHotelConstants.HotelACity,
                    Rating = await dbContext.Ratings.FirstOrDefaultAsync(r=>
                    r.Name==DefaultRatingConstants.Five), // 5 star rating's id
                    ReceptionPhone = DefaultHotelConstants.HotelAReceptionPhone,
                    ShuttleServicePhone = DefaultHotelConstants.HotelAShuttleServicePhone,
                    RestaurantPhone = DefaultHotelConstants.HotelARestaurantPhone,
                    Image = DefaultHotelConstants.HotelAImage,
                    //Assign This hotel's user to HotelUserA
                    User = userManager.Users.FirstOrDefault(u =>
                    u.UserName == DefaultUserConstants.HotelUserNameA) 
                },
                 new Models.Hotel
                 {
                     Name = DefaultHotelConstants.HotelBName,
                     Description = DefaultHotelConstants.HotelBDescription,
                     Address = DefaultHotelConstants.HotelBAdress,
                     City = DefaultHotelConstants.HotelBCity,
                     Rating = await dbContext.Ratings.FirstOrDefaultAsync(r =>
                     r.Name == DefaultRatingConstants.Four), // 4 star rating's id
                     ReceptionPhone = DefaultHotelConstants.HotelBReceptionPhone,
                     ShuttleServicePhone = DefaultHotelConstants.HotelBShuttleServicePhone,
                     RestaurantPhone = DefaultHotelConstants.HotelBRestaurantPhone,
                     Image = DefaultHotelConstants.HotelBImage,
                     //Assign This hotel's user to HotelUserB
                     User = userManager.Users.FirstOrDefault(u =>
                     u.UserName == DefaultUserConstants.HotelUserNameB)
                 }
                );
        }
    }
}
