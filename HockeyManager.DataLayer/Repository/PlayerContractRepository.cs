﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyManager.DataLayer.Repository
{
    public class PlayerContractRepository : GeneralRepository<PlayerContract>, IPlayerContractRepository
    {
        public PlayerContractRepository(GeneralContext context) : base(context)
        {

        }
    }
}