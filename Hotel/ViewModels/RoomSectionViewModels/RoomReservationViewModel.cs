using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Models;

namespace Hotel.ViewModels.RoomSectionViewModels
{
    public class RoomReservationViewModel
    {
        public Room Room { get; set; }
        public ICollection<RoomImage> Images { get; set; }
        public RoomImage MainImage { get; set; }
        public ICollection<Facility> Facilities { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        [Required(ErrorMessage ="Başlama tarixi qeyd olunmalıdır")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Son tarix qeyd olunmalıdır")]
        public DateTime EndDate { get; set; }
        [Required(ErrorMessage = "En azi 1 nefer boyuk olmalidir")]
        public int AdultCount { get; set; }
        [Required(ErrorMessage = "Bu hissə doldurulmalıdır")]
        public int ChildCount { get; set; }
        public int RoomId { get; set; }
    }
}
