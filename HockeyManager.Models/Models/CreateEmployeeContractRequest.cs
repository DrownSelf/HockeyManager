using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyManager.Models
{
    public class CreateEmployeeContractRequest
    {
        [Required(ErrorMessage = "Enter a valid value")]
        [Range(0, int.MaxValue)]
        [Display(Name = "USD Salary")]
        public int USDSalary { get; set; }

        [Required(ErrorMessage = "Enter a valid date")]
        [Display (Name = "Conclusion date")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfConclusion { get; set; }

        [Required(ErrorMessage = "Enter a valid date")]
        [Display(Name = "Ending date")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfEnding { get; set; }
    }
}
