using HockeyManager.DataLayer;
using HockeyManager.Models;
using Microsoft.AspNetCore.Identity;

namespace HockeyManager.Services
{
    public interface IEmployeeServise
    {
        public IEnumerable<Employee> Employees{ get; }

        public Task<bool> DeleteEmployeeAsync(string id, IEmployeeRoleService employeeRoleService);

        public Task<bool> CreateEmployeeAsync(CreateEmployeeRequest createEmployee);

        public Task<bool> UpdateEmployeeAsync(ChangeEmployeeRequest changeEmployee);
    }
}