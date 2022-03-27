using System.ComponentModel.DataAnnotations;

namespace HockeyManager.Models
{
    public class ChangeEmployeeRequest
    {
        public string EmployeeId { get; set; }

        [Required(ErrorMessage = "Enter a value")]
        [Display(Name = "USD Salary")]
        [Range (0, int.MaxValue)]
        public int USDSalary { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Wrong input")]
        public string Email { get; set; }
    }
}