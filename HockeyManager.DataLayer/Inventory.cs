using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyManager.DataLayer
{
    public class Inventory
    {
        public string InventoryId { get; set; }

        public string TypeOfAccessory { get; set; }
        
        public int Amount { get; set; }

        public string NameOfAccessory { get; set; }

        public DateTime DataOfLastMaintain { get; set; }
        
        public int USDCost { get; set; }
    }
}
