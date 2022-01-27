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
    public static class CommentGenerator
    {
        public static async Task GenerateCommentsAsync(this AppDbContext dbContext,
            UserManager<User>userManager)
        {
            await dbContext.Comments.AddRangeAsync(
                new Comment { 
                    Room=await dbContext.Rooms
                    .FirstOrDefaultAsync(r=>r.Name==DefaultRoomConstants.HotelARoomAName),
                    Rating=await dbContext.Ratings
                    .FirstOrDefaultAsync(r=>r.Name==DefaultRatingConstants.Five),
                    User= await userManager.Users
                    .FirstOrDefaultAsync(u=>u.UserName==DefaultUserConstants.HotelUserNameB),
                    Content="Dummy Comment 1 for Room A by Hotel User B"
                },
                 new Comment
                 {
                     Room = await dbContext.Rooms
                    .FirstOrDefaultAsync(r => r.Name == DefaultRoomConstants.HotelARoomAName),
                     Rating = await dbContext.Ratings
                    .FirstOrDefaultAsync(r => r.Name == DefaultRatingConstants.Four),
                     User = await userManager.Users
                    .FirstOrDefaultAsync(u => u.UserName == DefaultUserConstants.HotelUserNameB),
                     Content = "Dummy Comment 2 for Room A by Hotel User B",
                 }
                );
        }
    }
}
