using System.ComponentModel.DataAnnotations;

namespace HockeyManager.Models
{
    public class ChangePlayerStatisticRequest
    {
        public string PlayerStatisticId { get; set; }

        public string PlayerId { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Goals")]
        public int Goals { get; set; }

        [Range(0, int.MaxValue)]
        [Display(Name = "Assist")]
        public int Assist { get; set; }

        [Display(Name = "Shoots on goals")]
        [Range(0, double.PositiveInfinity)]
        public double ShootsOnGoals { get; set; }

        [Display(Name = "Benefit Index")]
        public int BenefitIndex { get; set; }

        [Display(Name = "Body Check/game")]
        [Range(0, double.PositiveInfinity)]
        public double BodyCheckingPerGame { get; set; }
    }
}