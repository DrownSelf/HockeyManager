using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyManager.DataLayer.Repository
{
    public class EmployeeContractRepository : GeneralRepository<EmployeeContract>, IEmployeeContractRepository
    {
        public EmployeeContractRepository(GeneralContext context) : base(context)
        {

        }
    }
}
