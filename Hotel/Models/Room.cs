using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class Room:Base
    {
        public string Name { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public byte Type { get; set; }
        public int Size { get; set; }
        public float Price { get; set; }
        public int ReservationCount { get; set; }
        public int Popularity { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Facility> Facilities { get; set; }
        public ICollection<RoomImage> RoomImages { get; set; }
        public Hotel Hotel { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
