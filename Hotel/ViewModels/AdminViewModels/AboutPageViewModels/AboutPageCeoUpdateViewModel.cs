using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Hotel.ViewModels.AdminViewModels.AboutPageViewModels
{
    public class AboutPageCeoUpdateViewModel
    {

        [Required(ErrorMessage = "Title daxil olunmalidir!")]
        public string CeoName { get; set; }
        [Required(ErrorMessage = "Description daxil olunmalidir!")]
        public string Description { get; set; }

        public string Image { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
