using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Models;
using Hotel.Utilities.ControllerUtilities.AdminHotelUtilities;

namespace Hotel.ViewModels.AdminViewModels.AdminHotelViewModels
{
    public class AdminHotelDetailViewModel
    {
        public Models.Hotel Hotel { get; set; }
        public ICollection<RoomAndImage> RoomAndImages { get; set; } = new List<RoomAndImage>();
    }
}
