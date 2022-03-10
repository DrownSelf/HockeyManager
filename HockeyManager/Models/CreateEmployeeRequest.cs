using System.ComponentModel.DataAnnotations;

namespace HockeyManager.Models
{
    public class CreateEmployeeRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Salary in USD")]
        [Range (0, int.MaxValue)]
        public int USDSalary { get; set; }

        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
