using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.DAL;
using Hotel.Models;
using Hotel.Utilities.ControllerUtilities.AdminHotelUtilities;
using Hotel.ViewModels.AdminViewModels.AdminRoomViewModels;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Utilities.ControllerUtilities.AdminRoomUtilities
{
    public static class UpdateRoomMapper
    {
        public async static Task<AdminRoomUpdateViewModel> MapAsync(Room room,AppDbContext dbContext)
        {
            ICollection<Facility>allFacilities = await dbContext.Facilities
                .Include(f=>f.Rooms).Where(f=>!f.IsDeleted).ToListAsync();
            ICollection<FacilityCheckBox> facilityCheckBox = new List<FacilityCheckBox>();
            foreach (Facility facility in allFacilities)
            {
                if (facility.Rooms.Any(r=>r.Id==room.Id)) {
                    facilityCheckBox.Add(new FacilityCheckBox {
                        Facility =facility,
                        Selected=true
                    });
                    continue;
                }
                facilityCheckBox.Add(new FacilityCheckBox
                {
                    Facility = facility,
                    Selected = false
                });
            }
            AdminRoomUpdateViewModel model = new() { 
            RoomId=room.Id,
            Title=room.Title,
            Description=room.Description,
            Facilities= facilityCheckBox.ToArray(),
            Size=room.Size,
            Name=room.Name,
            Price=room.Price,
            Type=room.Type,
            HotelId=room.Hotel.Id,
            HotelName=room.Hotel.Name,
            MainImageStr=(await dbContext.RoomImages.FirstOrDefaultAsync(r=>r.IsMain)).Name,
            };
            List<string> images = await dbContext.RoomImages
                .Where(r => r.Room == room).Select(r => r.Name).ToListAsync();
            foreach (string image in images)
            {
                model.ImageStrs.Add(image);
            }
            return model;
        }
    }
}
