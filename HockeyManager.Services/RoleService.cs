using HockeyManager.DataLayer.Repository;
using Microsoft.AspNetCore.Identity;

namespace HockeyManager.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public IEnumerable<IdentityRole> Roles
        {
            get
            {
                return _roleRepository.Entities;
            }
        }

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task<bool> CreateRoleAsync(string nameOfrole)
        {
            var newRole = new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = nameOfrole
            };
            var result = _roleRepository.CreateAsync(newRole);
            if(!result)
                return false;
            await _roleRepository.SaveAsync();
            return true;

        }

        public async Task<bool> DeleteRoleAsync(string roleId)
        {
            var findedRole = await _roleRepository.FindByIdAsync(roleId);
            if (findedRole == null || findedRole.Name == "admin")
                return false;
            _roleRepository.Delete(findedRole);
            await _roleRepository.SaveAsync();
            return true;
        }

        public async Task<bool> UpdateRoleAsync(string id, string newName)
        {
            var findedRole = await _roleRepository.FindByIdAsync(id);
            if (findedRole == null || findedRole.Name == "admin")
                return false;
            findedRole.Name = newName;
            findedRole.NormalizedName = newName.ToUpper();
            await _roleRepository.SaveAsync();
            return true;
        }
    }
}