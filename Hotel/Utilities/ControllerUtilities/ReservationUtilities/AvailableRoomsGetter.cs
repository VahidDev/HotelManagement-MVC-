using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.DAL;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Utilities.ControllerUtilities.ReservationUtilities
{
    public static class AvailableRoomsGetter
    {
        public async static Task<List<Room>> GetAvailableRoomsAsync(AppDbContext dbContext,
            DateTime startDate,DateTime endDate,int maxCount)
        {
            List<Room> rooms = await dbContext.Rooms.Where(r=>r.Type>=maxCount)
                .Include(r=>r.Hotel).Include(r=>r.Reservations)
                .Include(r=>r.RoomImages.Where(res=>res.IsMain))
                .Where(r => !r.IsDeleted).ToListAsync();
            List<Room> availableRooms = rooms.Where(r =>
            {
                return !DateChecker.IsConflicted(r, startDate, endDate);
            }).ToList();
            return availableRooms;
        }
    }
}
