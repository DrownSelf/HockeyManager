using System.ComponentModel.DataAnnotations;

namespace HockeyManager.Models
{
    public class CreatePlayerStatisticRequest
    {
        public string PlayerId { get; set; }
        
        [Required]
        [Range(0, int.MaxValue)]
        [Display(Name = "Goals")]
        public int Goals { get; set; }

        [Required]
        [Range (0, int.MaxValue)]
        [Display(Name = "Assist")]
        public int Assist { get; set; }

        [Required]
        [Display(Name = "Shoots on goals")]
        [Range(0, double.PositiveInfinity)]
        public double ShootsOnGoals { get; set; }

        [Required]
        [Display(Name = "Benefit Index")]
        public int BenefitIndex { get; set; }

        [Required]
        [Display(Name = "Body Check/game")]
        [Range(0, double.PositiveInfinity)]
        public double BodyCheckingPerGame { get; set; }
    }
}
