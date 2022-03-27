using System.ComponentModel.DataAnnotations;

namespace HockeyManager.Models
{
    public class CreateEmployeeRequest : ICreateRequest
    {
        [Required(ErrorMessage = "Enter Email")]
        [EmailAddress(ErrorMessage = "Wrong input")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter value(amount)")]
        [Display(Name = "Salary in USD")]
        [Range (0, int.MaxValue)]
        public int USDSalary { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
