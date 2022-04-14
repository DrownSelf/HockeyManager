using System.ComponentModel.DataAnnotations;

namespace HockeyManager.Models
{
    public class ChangePlayerContractRequest
    {
        public string ContractId { get; set; }
        
        [Range(0, int.MaxValue)]
        [Display(Name = "USD Salary")]
        public int USDSalary { get; set; }

        [Display(Name = "Conclusion date")]
        [DataType(DataType.DateTime)]
        public DateTime DayOfContractConclusion { get; set; }

        [Display(Name = "Ending date")]
        [DataType(DataType.DateTime)]
        public DateTime DayOfConctractEnding { get; set; }

        [Display(Name = "Benefits")]
        public string? Benefits { get; set; }
    }
}
