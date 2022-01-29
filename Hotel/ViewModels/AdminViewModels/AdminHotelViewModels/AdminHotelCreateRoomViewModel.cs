using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Hotel.Models;
using Hotel.Utilities.ControllerUtilities.AdminHotelUtilities;
using Microsoft.AspNetCore.Http;

namespace Hotel.ViewModels.AdminViewModels.AdminHotelViewModels
{
    public class AdminHotelCreateRoomViewModel
    {
        public int HotelId { get; set; }
        [Required(ErrorMessage = "Otag adi daxil olunmalidir!")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Title  daxil olunmalidir!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description adi daxil olunmalidir!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Otagin novu daxil olunmalidir!")]
        public byte Type { get; set; }
        [Required(ErrorMessage = "Otagin olchusu daxil olunmalidir!")]
        public int Size { get; set; }
        [Required(ErrorMessage = "Otagin qiymeti daxil olunmalidir!")]
        public float Price { get; set; }
        public FacilityCheckBox[] Facilities { get; set; }
        [Required(ErrorMessage = "Otagin shekilleri daxil olunmalidir!")]
        public IFormFile[] RoomImages { get; set; }
        [Required(ErrorMessage = "Otagin esas shekli daxil olunmalidir!")]
        public IFormFile MainImage { get; set; }
    }
}
