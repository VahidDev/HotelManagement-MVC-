using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.ViewModels.AdminViewModels.AdminHotelViewModels
{
    public class AdminHotelIndexViewModel
    {
        public ICollection<Models.Hotel> Hotels { get; set; }
    }
}
