using System.ComponentModel.DataAnnotations;

namespace HockeyManager.Models
{
    public class LogInRequest
    {
        [Required(ErrorMessage = "Enter Email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Wrong Input")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password, ErrorMessage = "Wrong input")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; } = false;
    }
}
