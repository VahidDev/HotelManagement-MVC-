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
    public class RoomAFacilityGetter
    {
        public async static Task<ICollection<Facility>> GetRoomAFacilities(AppDbContext dbContext)
        {
            ICollection<Facility> RoomAfacilities = new List<Facility>
            {
                await dbContext.Facilities
                 .FirstOrDefaultAsync(f => f.Name == DefaultFacilityConstants.HavalimaniTarnsferi),
                await dbContext.Facilities
                 .FirstOrDefaultAsync(f => f.Name == DefaultFacilityConstants.Kondisioner),
                await dbContext.Facilities
               .FirstOrDefaultAsync(f => f.Name == DefaultFacilityConstants.QapaliHovuz),
                await dbContext.Facilities
               .FirstOrDefaultAsync(f => f.Name == DefaultFacilityConstants.SmartTV)
            };
            return RoomAfacilities;
        }
    }
}
