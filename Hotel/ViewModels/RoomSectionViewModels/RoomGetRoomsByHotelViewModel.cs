using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Models;
using Hotel.Models.WebsiteSections;

namespace Hotel.ViewModels.RoomSectionViewModels
{
    public class RoomGetRoomsByHotelViewModel
    {
        public Models.Hotel Hotel { get; set; }
        public ICollection<Room> Rooms { get; set; }
    }
}
