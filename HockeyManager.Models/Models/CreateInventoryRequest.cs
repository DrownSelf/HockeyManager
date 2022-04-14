using System.ComponentModel.DataAnnotations;

namespace HockeyManager.Models
{
    public class CreateInventoryRequest
    {
        [Required]
        [Display(Name = "Type of Accessor")]
        public string TypeOfAccessory { get; set; }

        [Required(ErrorMessage = "Enter a valid value")]
        [Display(Name = "Amount of product")]
        [Range(0, int.MaxValue)]
        public int Amount { get; set; }

        [Required]
        [Display(Name = "Name of Accessor")]
        public string NameOfAccessory { get; set; }

        [Required]
        [Display(Name = "Last Maintain")]
        [DataType(DataType.DateTime)]
        public DateTime DataOfLastMaintain { get; set; }

        [Required]
        [Display(Name = "USD Cost of Accessor")]
        [Range(0, int.MaxValue)]
        public int USDCost { get; set; }
    }
}
