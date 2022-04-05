using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyManager.DataLayer.Repository
{
    public class PlayerRepository : GeneralRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(GeneralContext context) : base(context)
        {

        }
    }
}