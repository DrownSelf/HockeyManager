using HockeyManager.DataLayer;
using HockeyManager.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyManager.Services
{
    public interface IEmployeeRoleService
    {
        public Task<IList<string>> GetRolesOfEmployeeAsync(Employee employee);

        public Task<bool> EditRoleState(SetRoleRequest setRoleRequest);
    }
}
