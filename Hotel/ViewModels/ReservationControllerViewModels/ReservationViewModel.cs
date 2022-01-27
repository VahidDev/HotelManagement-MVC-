using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Models;

namespace Hotel.ViewModels.ReservationControllerViewModels
{
    public class ReservationViewModel
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
