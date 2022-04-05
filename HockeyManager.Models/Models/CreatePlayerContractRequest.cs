using System.ComponentModel.DataAnnotations;

namespace HockeyManager.Models
{
    public class CreatePlayerContractRequest
    {
        public string PlayerId { get; set; }

        [Required]
        [Range(0, int.MaxValue)]
        [Display(Name = "USD Salary")]
        public int USDSalary { get; set; }

        [Required(ErrorMessage = "Enter a valid date")]
        [Display(Name = "Conclusion date")]
        [DataType(DataType.DateTime)]
        public DateTime DayOfContractConclusion { get; set; }

        [Required(ErrorMessage = "Enter a valid date")]
        [Display(Name = "Ending date")]
        [DataType(DataType.DateTime)]
        public DateTime DayOfConctractEnding { get; set; }

        [Display(Name = "Benefits")]
        public string? Benefits { get; set; }
    }
}
