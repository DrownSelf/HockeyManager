using System.ComponentModel.DataAnnotations;

namespace HockeyManager.Models
{
    public class ChangePlayerRequest
    {
        public string PlayerId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Display(Name = "Position")]
        public string Position { get; set; }

        [Display(Name = "Is captain?")]
        public bool Captain { get; set; }
    }
}
