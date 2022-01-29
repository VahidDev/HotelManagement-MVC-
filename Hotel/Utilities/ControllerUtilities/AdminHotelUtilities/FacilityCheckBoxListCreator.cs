using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.DAL;
using Hotel.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Utilities.ControllerUtilities.AdminHotelUtilities
{
    public static class FacilityCheckBoxListCreator
    {
        public async static Task<List<FacilityCheckBox>> CreateAsync(AppDbContext dbContext)
        {
            List<FacilityCheckBox> facilityCheckBoxList = new List<FacilityCheckBox>();
            List<Facility> Facilities = await dbContext.Facilities.Where(f => !f.IsDeleted).ToListAsync();
            foreach (Facility facility in Facilities)
            {
                facilityCheckBoxList.Add(new FacilityCheckBox
                {
                    Facility = facility,
                });
            }
            return facilityCheckBoxList;
        }
    }
}
