using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Hotel.ViewModels.AdminViewModels.AboutPageViewModels
{
    public class AboutPageBannerUpdateViewModel
    {
        [Required(ErrorMessage ="Title daxil olunmalidir!")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description daxil olunmalidir!")]
        public string Description { get; set; }

        public string Image { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
