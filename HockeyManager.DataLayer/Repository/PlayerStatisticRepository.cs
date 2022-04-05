using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyManager.DataLayer.Repository
{
    public class PlayerStatisticRepository : GeneralRepository<PlayerStatistic>, IPlayerStatisticRepository
    {
        public PlayerStatisticRepository(GeneralContext context) : base(context)
        {

        }
    }
}
