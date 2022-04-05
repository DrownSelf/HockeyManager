using HockeyManager.DataLayer;
using HockeyManager.DataLayer.Repository;
using HockeyManager.Models;
using Microsoft.AspNetCore.Identity;

namespace HockeyManager.Services
{
    public class EmployeeRoleService : IEmployeeRoleService
    {
        private IEmployeeRoleRepository _employeeRoleRepository;
        private IEmployeeRepository _employeeRepository;
        private IRoleRepository _roleRepository;

        public EmployeeRoleService(IEmployeeRoleRepository employeeRoleRepository, IEmployeeRepository employeeRepository, IRoleRepository roleRepository)
        {
            _employeeRoleRepository = employeeRoleRepository;
            _employeeRepository = employeeRepository;
            _roleRepository = roleRepository;
        }

        private IList<string> FindRoles(IEnumerable<string> userRoles, IEnumerable<IdentityRole> roles)
        {
            List<string> findedRoles = new List<string>();
            foreach (var role in roles)
                foreach (var RoleId in userRoles)
                    if (role.Id == RoleId)
                        findedRoles.Add(role.Name);
            return findedRoles;
        }

        private IEnumerable<string> TranslateNamesToId(IEnumerable<string> roles)
        {
            var allRoles = _roleRepository.Entities;
            var translatedRoles = new List<string>();
            foreach (var roleName in roles)
                foreach (var role in allRoles)
                    if (role.Name == roleName)
                        translatedRoles.Add(role.Id);
            return translatedRoles;
        }

        public Task<IList<string>> GetRolesOfEmployeeAsync(Employee employee)
        {
            return Task<IList<string>>.Factory.StartNew(
                () =>
                {
                    var rolesId = _employeeRoleRepository.Entities
                    .Where(role => role.UserId == employee.Id)
                    .Select(r => r.RoleId).ToList();

                    IEnumerable<IdentityRole> roles = _roleRepository.Entities;

                    return FindRoles(rolesId, roles);
                });
        }

        private Task AddRolesToEmployeeAsync(Employee employee, IEnumerable<string> roles)
        {
            return Task.Run(() => AddRolesToEmployee(employee, roles));
        }

        private void AddRolesToEmployee(Employee employee, IEnumerable<string> roles)
        {
            IEnumerable<string> RoleIdStore = TranslateNamesToId(roles);
            foreach (var roleId in RoleIdStore)
            {
                var userRole = new IdentityUserRole<string>
                {
                    RoleId = roleId,
                    UserId = employee.Id
                };
                _employeeRoleRepository.CreateAsync(userRole);
            }
        }

        public Task RemoveRolesFromEmployeeAsync(Employee employee, IEnumerable<string> roles)
        {
            return Task.Run(() => RemoveRolesFromEmployee(employee, roles));
        }

        public void RemoveRolesFromEmployee(Employee employee, IEnumerable<string> roles)
        {
            IEnumerable<string> RoleIdStore = TranslateNamesToId(roles);
            var userRoles = _employeeRoleRepository.Entities;
            foreach (var userRole in userRoles)
                foreach (var roleId in RoleIdStore)
                    if (userRole.RoleId == roleId && userRole.UserId == employee.Id)
                        _employeeRoleRepository.Delete(userRole);
        }

        public async Task<bool> EditRoleState(SetRoleRequest setRoleRequest)
        {
            var findedUser = await _employeeRepository.FindByIdAsync(setRoleRequest.UserId);
            if (findedUser == null)
                return false;

            var employeeRoles = await GetRolesOfEmployeeAsync(findedUser);
            var deletedRoles = employeeRoles.Except(setRoleRequest.Roles).ToList();
            var addedRoles = setRoleRequest.Roles.Except(employeeRoles).ToList();

            await AddRolesToEmployeeAsync(findedUser, addedRoles);
            await RemoveRolesFromEmployeeAsync(findedUser, deletedRoles);
            await _employeeRoleRepository.SaveAsync();
            return true;
        }

    }
}