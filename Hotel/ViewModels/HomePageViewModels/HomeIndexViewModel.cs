using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hotel.Models;
using Hotel.Models.WebsiteSections;
using Hotel.Models.WebsiteSections.SubWebsiteSections;

namespace Hotel.ViewModels.HomePageViewModels
{
    public class HomeIndexViewModel
    {
        public HotelBannerSection HotelBannerSection { get; set; }
        public ICollection<Facility> Facilities { get; set; }
        public HotelInfoSection HotelInfoSection { get; set; }
        public HotelTransitionSection HotelTransitionSection { get; set; }
        public ICollection<HotelTransitionSectionImage>HotelTransitionSectionImages { get; set; }
        public HotelShowcaseSection HotelShowcaseSection{ get; set; }
        public HotelCommentSection HotelCommentSection{ get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Room> Rooms { get; set; }
        [Required(ErrorMessage ="Bashlangic tarix qeyd olunmalidir")]
        public DateTime ReservationStart { get; set; }
        [Required(ErrorMessage = "Son tarix qeyd olunmalidir")]
        public DateTime ReservationEnd { get; set; }
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }

    }
}
