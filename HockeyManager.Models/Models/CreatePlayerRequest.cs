using System.ComponentModel.DataAnnotations;

namespace HockeyManager.Models
{
    public class CreatePlayerRequest
    {
        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [Display(Name = "Position")]
        public string Position { get; set; }

        [Required]
        [Display(Name = "Is captain?")]
        public bool Captain { get; set; }
    }
}
