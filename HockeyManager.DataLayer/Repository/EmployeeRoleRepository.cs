using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyManager.DataLayer.Repository
{
    public class EmployeeRoleRepository : GeneralRepository<IdentityUserRole<string>>, IEmployeeRoleRepository
    {
        public EmployeeRoleRepository(GeneralContext context) : base(context)
        {

        }
    }
}