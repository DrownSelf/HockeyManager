using System.ComponentModel.DataAnnotations;

namespace HockeyManager.Models
{
    public class CreateEmployeeRequest
    {
        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress(ErrorMessage = "Wrong input")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password, ErrorMessage = "Wrong Password Input")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter confirm")]
        [Display(Name = "Password")]
        [Compare("Password", ErrorMessage = "Password not match")]
        [DataType(DataType.Password, ErrorMessage = "Wrong Password Input")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Salary in USD")]
        [Range(0, int.MaxValue)]
        public int USDSalary { get; set; }

        [Display(Name = "Contract Conclusion")]
        [DataType(DataType.DateTime)]
        public DateTime DayOfContractConclusion { get; set; }

        [Display(Name = "Contract Ending")]
        [DataType(DataType.DateTime)]
        public DateTime DayOfConctractEnding { get; set; }
    }
}