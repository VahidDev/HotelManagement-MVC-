using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.ViewModels.AccountViewModels
{
    
    public class AccountLoginViewModel
    {
        [Required(ErrorMessage ="Istifadeci adi daxil etmelisiniz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Shifre daxil olunmalidir"),DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
