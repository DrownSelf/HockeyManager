 using System.ComponentModel.DataAnnotations;

namespace HockeyManager.Models
{
    public class RegisterRequest
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Display(Name = "Confirm Password")]
        [Compare ("Password", ErrorMessage = "Password not match")]
        [DataType (DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}