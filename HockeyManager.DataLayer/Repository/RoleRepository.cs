using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyManager.DataLayer.Repository
{
    public class RoleRepository : GeneralRepository<IdentityRole>, IRoleRepository
    {
        public RoleRepository(GeneralContext context) : base(context)
        {

        }
    }
}
