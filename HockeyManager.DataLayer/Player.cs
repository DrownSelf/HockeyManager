using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyManager.DataLayer
{
    public class Player
    {
        public string PlayerId { get; set; }

        public PlayerContract PlayerContract { get; set; }

        public PlayerStatistic PlayerStatistics { get; set; }
        
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Position { get; set; }

        public bool Captain { get; set; }
    }
}
