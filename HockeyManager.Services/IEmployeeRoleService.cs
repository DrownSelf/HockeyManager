using HockeyManager.DataLayer;
using HockeyManager.Models;

namespace HockeyManager.Services
{
    public interface IEmployeeRoleService
    {
        public Task<IList<string>> GetRolesOfEmployeeAsync(Employee employee);

        public Task<bool> EditRoleState(SetRoleRequest setRoleRequest);
    }
}
