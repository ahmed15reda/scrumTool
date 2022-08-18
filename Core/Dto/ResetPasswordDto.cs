using System.ComponentModel.DataAnnotations;

namespace Core.Dto
{
    public class ResetPasswordDto
    {
        [Required]
        public string CurrentPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        [Compare("NewPassword", ErrorMessage = "confirm new password doesn't match")]
        public string ConfirmNewPassword { get; set; }
    }
}
