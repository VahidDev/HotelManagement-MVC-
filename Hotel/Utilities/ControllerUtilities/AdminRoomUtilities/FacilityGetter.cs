using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.DAL;
using Hotel.Models;
using Hotel.Utilities.ControllerUtilities.AdminHotelUtilities;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Utilities.ControllerUtilities.AdminRoomUtilities
{
    public static class FacilityGetter
    {
        public async static Task<FacilityCheckBox[]> GetAllFacilities(AppDbContext _dbContext)
        {
            ICollection<Facility> allFacilities = await _dbContext.Facilities
               .Where(f => !f.IsDeleted).ToListAsync();
            ICollection<FacilityCheckBox> facilityCheckBoxes = new List<FacilityCheckBox>();
            foreach (Facility facility in allFacilities)
            {
                facilityCheckBoxes.Add(new FacilityCheckBox
                {
                    Facility = facility,
                    Selected = false
                });
            }
            return facilityCheckBoxes.ToArray();
        }
    }
}
