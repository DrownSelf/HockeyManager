using HockeyManager.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyManager.Services
{
    public interface IRoleService
    {
        public IEnumerable<IdentityRole> Roles { get; }

        public Task<bool> DeleteRoleAsync(string roleId);

        public Task<bool> CreateRoleAsync(string nameOfrole);

        public Task<bool> UpdateRoleAsync(string id, string newName);
    }
}
