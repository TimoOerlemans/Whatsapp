
using System.ComponentModel.DataAnnotations;

namespace DataConnect.Models
{
    public class ChangePasswordViewModel
    {
        [Required(ErrorMessage = "Field cannot be empty")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        public string NewPassword1 { get; set; }

        [Required(ErrorMessage = "Field cannot be empty")]
        public string NewPassword2 { get; set; }

        public ChangePasswordViewModel()
        {

        }
    }
}
