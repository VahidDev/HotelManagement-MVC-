using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Models;
using Hotel.Models.WebsiteSections.AboutPageSections;

namespace Hotel.ViewModels.AboutPageViewModels
{
    public class AboutPageIndexViewModel
    {
        public ICollection<Facility> Facilities { get; set; }
        public AboutPageBannerSection AboutPageBanner{ get; set; }
        public AboutPageCeoSection AboutPageCeo { get; set; }
    }
}
