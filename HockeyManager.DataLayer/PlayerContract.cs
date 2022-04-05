using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyManager.DataLayer
{
    public class PlayerContract
    {
        public string PlayerContractId { get; set; }

        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public int USDSalary { get; set; }

        public DateTime DayOfContractConclusion { get; set; }

        public DateTime DayOfConctractEnding { get; set; }

        public string? Benefits { get; set; }
    }
}
