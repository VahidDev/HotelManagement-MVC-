using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Models;

namespace Hotel.Utilities.ControllerUtilities.AdminHotelUtilities
{
    public class FacilityCheckBox
    {
        public bool Selected { get; set; } = false;
        public Facility Facility { get; set; }
    }
}
