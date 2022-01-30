using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Models;

namespace Hotel.ViewModels.AdminViewModels.AdminRoomViewModels
{
    public class AdminRoomDetailViewModel
    {
        public Room Room { get; set; }
        public string HotelName { get; set; }
        public string MainImage { get; set; }
        public ICollection<string> Images { get; set; }
        public int HotelId { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
