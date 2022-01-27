using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models.WebsiteSections
{
    public class HotelInfoSection:Base
    {
        public string FirstImage { get; set; }
        public string FirstImageTitle { get; set; }
        public string FirstImageDescription { get; set; }
        public string SecondImage { get; set; }
        public string SecondImageTitle { get; set; }
        public string SecondImageDescription { get; set; }
    }
}
