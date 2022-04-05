using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyManager.DataLayer.Repository
{
    public class InventoryRepository : GeneralRepository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(GeneralContext context) : base(context)
        {

        }
    }
}
