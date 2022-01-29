using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Hotel:Base
    {
        public string Name { get; set; }
        public Rating Rating { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int Popularity { get; set; } = 0;
        public string Address { get; set; }
        public string City { get; set; }
        public int RoomCount { get; set; } = 0;
        public int ReservationCount { get; set; } = 0;
        public string RestaurantPhone { get; set; }
        public string ReceptionPhone { get; set; }
        public string ShuttleServicePhone { get; set; }
        public ICollection<Room> Rooms { get; set; }
        public User User { get; set; }
    }
}
