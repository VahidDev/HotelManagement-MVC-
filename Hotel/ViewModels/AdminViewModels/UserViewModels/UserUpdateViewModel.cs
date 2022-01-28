using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.ViewModels.AdminViewModels.UserViewModels
{
    public class UserUpdateViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="User name daxil olunmalidir!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email daxil olunmalidir!"),
            DataType(DataType.EmailAddress,ErrorMessage ="Email duzgun formatda deyil!")]
        public string Email { get; set; }
    }
}
