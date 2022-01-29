using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Models;
using Microsoft.AspNetCore.Http;

namespace Hotel.ViewModels.AdminViewModels.AdminHotelViewModels
{
    public class AdminHotelCreateViewModel
    {
        public string UserId { get; set; }
        [Required(ErrorMessage ="Hotel adi daxil olunmalidir!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Rating daxil olunmalidir!")]
        public int RatingId { get; set; }
        [Required(ErrorMessage = "Description daxil olunmalidir!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Address daxil olunmalidir!")]
        public string Address { get; set; }
        [Required(ErrorMessage = "City daxil olunmalidir!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Shekil daxil olunmalidir!")]
        public IFormFile ImageFile { get; set; }
        [Required(ErrorMessage = "Restarant nomresi daxil olunmalidir!")]
        public string RestaurantPhone { get; set; }
        [Required(ErrorMessage = "Resepshin nomresi daxil olunmalidir!")]
        public string ReceptionPhone { get; set; }
        [Required(ErrorMessage = "Shuttle service nomresi daxil olunmalidir!")]
        public string ShuttleServicePhone { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}
