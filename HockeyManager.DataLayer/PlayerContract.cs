using System.ComponentModel.DataAnnotations;

namespace HockeyManager.DataLayer
{
    public class PlayerContract
    {
        [Key]
        public string PlayerContractId { get; set; }

        public string PlayerId { get; set; }

        public Player Player { get; set; }

        public int USDSalary { get; set; }

        public DateTime DayOfContractConclusion { get; set; }

        public DateTime DayOfConctractEnding { get; set; }

        public string? Benefits { get; set; }
    }
}