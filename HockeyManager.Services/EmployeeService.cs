using HockeyManager.DataLayer;
using HockeyManager.DataLayer.Repository;
using HockeyManager.Models;
using Microsoft.AspNetCore.Identity;

namespace HockeyManager.Services
{
    public class EmployeeService : IEmployeeServise
    {
        public IEnumerable<Employee> Employees 
        { 
            get 
            { 
                return _employeeRepository.Entities; 
            }
        }
        
        private IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        private Employee InitEmployee(ICreateRequest createRequest)
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
            return newEmployee;
        }

        public async Task<bool> RegisterEmployeeAsync(RegisterRequest registerRequest)
        {
            try
            {
                var employee = InitEmployee(registerRequest);
                await _employeeRepository.CreateAsync(employee);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> CreateEmployeeAsync(CreateEmployeeRequest createRequest)
        {
            try
            {
                var newEmployee = InitEmployee(createRequest);
                newEmployee.USDSallary = createRequest.USDSalary;
                await _employeeRepository.CreateAsync(newEmployee);
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }

        public async Task<bool> DeleteEmployeeAsync(string id)
        {
            //if (await _employeeService.IsInRoleAsync(findedEmployee, "admin"))
            //    return BadRequest("You can't delete admin"); 
            var findedEmployee = await _employeeRepository.FindByIdAsync(id);
            if (findedEmployee == null)
                return false;
            _employeeRepository.Delete(findedEmployee);
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
            findedEmployee.USDSallary = changeEmployee.USDSalary;
            findedEmployee.UserName = findedEmployee.Email;
            await _employeeRepository.SaveAsync();
            return true;
        }
    }
}