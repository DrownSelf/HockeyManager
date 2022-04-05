using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyManager.Models
{
    public class ChangeEmployeeContractRequest
    {
        public string EmployeeContractId { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "USD Salary")]
        public int USDSalary { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Conslusion Date")]
        public DateTime dayOfConclusion { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Ending Date")]
        public DateTime dayOfEnding { get; set; }
    }
}
