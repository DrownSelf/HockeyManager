using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyManager.DataLayer
{
    public class EmployeeContract
    {
        public string EmployeeContractId { get; set; }

        public string EmployeeId { get; set; }

        public Employee Employee { get; set; }

        public int USDSalary { get; set; }

        public DateTime DayOfContractConclusion { get; set; }

        public DateTime DayOfConctractEnding { get; set; }
    }
}
