using HockeyManager.DataLayer;
using HockeyManager.DataLayer.Repository;
using HockeyManager.Models;
using Microsoft.AspNetCore.Identity;

namespace HockeyManager.Services
{
    public class EmployeeService : IEmployeeServise
    {
        private IEmployeeRepository _employeeRepository;

        public IEnumerable<Employee> Employees
        {
            get
            {
                return _employeeRepository.Entities;
            }
        }

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> CreateEmployeeAsync(CreateEmployeeRequest createRequest)
        {
            var newEmployee = new Employee
            {
                Id = Guid.NewGuid().ToString(),
                Email = createRequest.Email,
                UserName = createRequest.Email,
                NormalizedEmail = createRequest.Email.ToUpper(),
                NormalizedUserName = createRequest.Email.ToUpper()
            };
            newEmployee.PasswordHash = new PasswordHasher<Employee>().HashPassword(newEmployee, createRequest.Password);
            var result = _employeeRepository.CreateAsync(newEmployee);
            if (!result)
                return false;
            await _employeeRepository.SaveAsync();
            return true;
        }

        public async Task<bool> DeleteEmployeeAsync(string id, IEmployeeRoleService employeeRoleService)
        {
            var findedEmployee = await _employeeRepository.FindByIdAsync(id);
            if (findedEmployee == null)
                return false;
            
            var roleList = await employeeRoleService.GetRolesOfEmployeeAsync(findedEmployee);
            var result = roleList.Contains("admin");
            if(result)
                return false;
            _employeeRepository.Delete(findedEmployee);
            await _employeeRepository.SaveAsync();
            return true;
        }

        public async Task<bool> UpdateEmployeeAsync(ChangeEmployeeRequest changeEmployee)
        {
            var findedEmployee = await _employeeRepository.FindByIdAsync(changeEmployee.EmployeeId);
            if (findedEmployee == null)
                return false;

            findedEmployee.Email = changeEmployee.Email;
            findedEmployee.NormalizedEmail = findedEmployee.Email.ToUpper();
            findedEmployee.NormalizedUserName = findedEmployee.NormalizedEmail;
            findedEmployee.UserName = findedEmployee.Email;
            await _employeeRepository.SaveAsync();
            return true;
        }
    }
}