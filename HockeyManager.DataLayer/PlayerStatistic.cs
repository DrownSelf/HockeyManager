using System.ComponentModel.DataAnnotations;

namespace HockeyManager.DataLayer
{
    public class PlayerStatistic
    {
        [Key]
        public string StatsId { get; set; }

        public Player Player { get; set; }

        public string PlayerId { get; set; }

        public int Goals { get; set; }

        public int Assist { get; set; }

        public int Points { get; set; }

        public double ShootsOnGoals { get; set; }

        public int BenefitIndex { get; set; }

        public double BodyCheckingPerGame { get; set; }
    }
}