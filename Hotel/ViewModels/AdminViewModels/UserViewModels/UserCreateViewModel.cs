using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.ViewModels.AdminViewModels.UserViewModels
{
    public class UserCreateViewModel
    {
        [Required(ErrorMessage = "Istifadeci adi daxil etmelisiniz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Shifre daxil olunmalidir"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Tekrar shifre daxil olunmalidir"), DataType(DataType.Password),
        Compare(nameof(Password), ErrorMessage = "Shifreler uygun deyl")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Email daxil etmelisiniz"),
         DataType(DataType.EmailAddress, ErrorMessage = "Duzgun email daxil edin!")]
        public string Email { get; set; }
    }
}
