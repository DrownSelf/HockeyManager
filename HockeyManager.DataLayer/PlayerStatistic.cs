using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyManager.DataLayer
{
    public class PlayerStatistic
    {
        public Player Player { get; set; }

        public string StatsId { get; set; }

        public string PlayerId { get; set; }

        public int Goals { get; set; }

        public int Assist { get; set; }

        public int Points { get; set; }

        public double ShootsOnGoals { get; set; }

        public int BenefitIndex { get; set; }

        public double BodyCheckingPerGame { get; set; }
    }
}
