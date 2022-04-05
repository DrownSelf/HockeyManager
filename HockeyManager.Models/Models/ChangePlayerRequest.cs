using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
