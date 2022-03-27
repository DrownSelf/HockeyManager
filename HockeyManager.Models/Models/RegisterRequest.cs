 using System.ComponentModel.DataAnnotations;

namespace HockeyManager.Models
{
    public class RegisterRequest : ICreateRequest
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Wrong Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password, ErrorMessage = "Password got to have one big letter, little letter and one symbol")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter Confirm")]
        [Display(Name = "Confirm Password")]
        [Compare ("Password", ErrorMessage = "Password not match")]
        [DataType (DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}