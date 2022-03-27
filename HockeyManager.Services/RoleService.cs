using HockeyManager.DataLayer.Repository;
using HockeyManager.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HockeyManager.Services
{
    public class RoleService : IRoleService
    {
        public IEnumerable<IdentityRole> Roles 
        { 
            get
            {
                return _roleRepository.Entities;
            } 
        } 
        
        private readonly IRoleRepository _roleRepository;
        private readonly IEmployeeRepository _employeeRepository;

        public RoleService(IRoleRepository roleRepository, IEmployeeRepository employeeRepository)
        {
            _roleRepository = roleRepository;
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> CreateRoleAsync(string nameOfrole)
        {
            try
            {
                var newRole = new IdentityRole()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = nameOfrole
                };
                await _roleRepository.CreateAsync(newRole);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> DeleteRoleAsync(string roleId)
        {
            var findedRole = await _roleRepository.FindByIdAsync(roleId);
            if (findedRole == null)
                return false;
            _roleRepository.Delete(findedRole);
            return true;
        }

        public async Task<bool> UpdateRoleAsync(string id, string newName)
        {
            var findedRole = await _roleRepository.FindByIdAsync(id);
            if (findedRole == null)
                return false;
            findedRole.Name = newName;
            findedRole.NormalizedName = newName.ToUpper();
            await _roleRepository.SaveAsync();
            return true;
        }
    }
}
