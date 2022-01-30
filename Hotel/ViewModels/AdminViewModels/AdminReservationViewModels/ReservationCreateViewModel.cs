using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Models;

namespace Hotel.ViewModels.AdminViewModels.AdminReservationViewModels
{
    public class ReservationCreateViewModel
    {

        [Required(ErrorMessage = "Bashlangic vaxt daxil olunmalidir!")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Son vaxt daxil olunmalidir!")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "En azi 1 nefer vaxt daxil olunmalidir!")]
        public int AdultCount { get; set; }
        public int ChildCount { get; set; }
        public int HotelId { get; set; }
        public string HotelName { get; set; }
        public string RoomName { get; set; }
        public int RoomId { get; set; }
        public int MaxPeopleCount { get; set; }
    }
}
