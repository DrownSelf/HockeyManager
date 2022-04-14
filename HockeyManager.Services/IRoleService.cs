using Microsoft.AspNetCore.Identity;

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
