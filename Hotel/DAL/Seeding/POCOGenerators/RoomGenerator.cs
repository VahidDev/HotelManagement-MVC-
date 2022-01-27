using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Constants.POCOConstants;
using Hotel.Models;
using Hotel.Utilities.Seeding_utilities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.DAL.Seeding.POCOGenerators
{
    public static class RoomGenerator
    {
        public static async Task GenerateRoomAsync(this AppDbContext dbContext)
        {
            ICollection<Facility> RoomAfacilities = await RoomAFacilityGetter.GetRoomAFacilities(dbContext);
            ICollection<RoomImage> RoomAImages = RoomAImageGetter.GetRoomAImages();
            ICollection<Facility> RoomBfacilities = await RoomBFacilityGetter.GetRoomBFacilities(dbContext);
            ICollection<RoomImage> RoomBImages = RoomBImageGetter.GetRoomBImages();
            await dbContext.Rooms.AddRangeAsync(
                new Room { 
                    Name=DefaultRoomConstants.HotelARoomAName,
                    Description=DefaultRoomConstants.HotelARoomADescription,
                    Facilities= RoomAfacilities,
                    Hotel=await dbContext.Hotels
                    .FirstOrDefaultAsync(h=>h.Name==DefaultHotelConstants.HotelAName),
                    Size=100,
                    Price=500,
                    Title= DefaultRoomConstants.HotelARoomTitle,
                    Type=2,
                    RoomImages= RoomAImages
                }
                );
            await dbContext.Rooms.AddRangeAsync(
               new Room
               {
                   Name = DefaultRoomConstants.HotelARoomBName,
                   Description = DefaultRoomConstants.HotelARoomBDescription,
                   Facilities = RoomBfacilities,
                   Hotel = await dbContext.Hotels
                   .FirstOrDefaultAsync(h => h.Name == DefaultHotelConstants.HotelAName),
                   Size = 80,
                   Price = 300,
                   Title = DefaultRoomConstants.HotelBRoomTitle,
                   Type = 3,
                   RoomImages= RoomBImages
               }
               );
        }
    }
}
