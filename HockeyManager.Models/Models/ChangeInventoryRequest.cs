using System.ComponentModel.DataAnnotations;

namespace HockeyManager.Models
{
    public class ChangeInventoryRequest
    {
        public string InventoryId { get; set; }
        
        [Display(Name = "Type of Accessor")]
        public string TypeOfAccessory { get; set; }

        [Display(Name = "Amount of product")]
        [Range(0, int.MaxValue)]
        public int Amount { get; set; }

        [Display(Name = "Name of Accessor")]
        public string NameOfAccessory { get; set; }

        [Display(Name = "Last Maintain")]
        [DataType(DataType.DateTime)]
        public DateTime DataOfLastMaintain { get; set; }

        [Display(Name = "USD Cost of Accessor")]
        [Range(0, int.MaxValue)]
        public int USDCost { get; set; }
    }
}
