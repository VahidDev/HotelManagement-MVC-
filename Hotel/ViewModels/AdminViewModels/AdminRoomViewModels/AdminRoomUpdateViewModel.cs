using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hotel.Utilities.ControllerUtilities.AdminHotelUtilities;
using Microsoft.AspNetCore.Http;

namespace Hotel.ViewModels.AdminViewModels.AdminRoomViewModels
{
    public class AdminRoomUpdateViewModel
    {
        public int RoomId { get; set; }
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
        [Required(ErrorMessage = "Otagin facilities-lari daxil olunmalidir!")]
        public FacilityCheckBox[] Facilities { get; set; }
        public IFormFile[] RoomImages { get; set; }
        public IFormFile MainImage { get; set; }
        public string HotelName { get; set; }
        public int HotelId{ get; set; }
        public string MainImageStr { get; set; }
        public ICollection<string> ImageStrs { get; set; } = new List<string>();
    }
}
