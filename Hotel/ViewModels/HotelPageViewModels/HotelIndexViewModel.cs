using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Models.WebsiteSections;
namespace Hotel.ViewModels.HotelPageViewModels
{
    public class HotelIndexViewModel
    {
        public HotelPageBannerSection HotelPageBannerSection { get; set; }
        public ICollection<Models.Hotel> Hotels { get; set; }
    }
}
