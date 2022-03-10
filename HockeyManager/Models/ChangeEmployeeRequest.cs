using System.ComponentModel.DataAnnotations;

namespace HockeyManager.Models
{
    public class ChangeEmployeeRequest
    {
        public string EmployeeId { get; set; }

        [Display(Name = "USD Salary")]
        [Range (0, int.MaxValue)]
        public int USDSalary { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}