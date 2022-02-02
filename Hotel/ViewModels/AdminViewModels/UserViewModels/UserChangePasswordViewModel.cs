using System.ComponentModel.DataAnnotations;

namespace Hotel.ViewModels.AdminViewModels.UserViewModels
{
    public class UserChangePasswordViewModel
    {
        public string Id { get; set; }
        [Required(ErrorMessage ="You need to include the old password!"),DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Required(ErrorMessage ="You need to include a new password!"),DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required(ErrorMessage ="You need to confirm the new password!"),DataType(DataType.Password),
            Compare(nameof(NewPassword),ErrorMessage ="The passwords do not match!")]
        public string ConfirmPassword { get; set; }
    }
}
