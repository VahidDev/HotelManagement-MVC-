using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Constants.POCOConstants;
using Hotel.DAL;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Utilities.Seeding_utilities
{
    public class RoomBFacilityGetter
    {
        public async static Task<ICollection<Facility>> GetRoomBFacilities(AppDbContext dbContext)
        {
            ICollection<Facility> RoomBfacilities = new List<Facility>
            {
                await dbContext.Facilities
                 .FirstOrDefaultAsync(f => f.Name == DefaultFacilityConstants.Yemek),
                await dbContext.Facilities
                 .FirstOrDefaultAsync(f => f.Name == DefaultFacilityConstants.WiFi)
            };
            return RoomBfacilities;
        }
    }
}
