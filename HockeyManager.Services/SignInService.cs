using HockeyManager.DataLayer;
using HockeyManager.DataLayer.Repository;
using HockeyManager.Models;
using Microsoft.AspNetCore.Identity;

namespace HockeyManager.Services
{
    public class SignInService : ISignInService
    {
        private SignInManager<Employee> _signInManager;
        private IEmployeeRepository _employeeRepository;

        public SignInService(SignInManager<Employee> signInManager, IEmployeeRepository employeeRepository)
        {
            _signInManager = signInManager;
            _employeeRepository = employeeRepository;
        }

        private Employee? FindEmployeeByEmail(string email)
        {
            var employees = _employeeRepository.Entities;
            foreach (var employee in employees)
                if(employee.Email == email)
                    return employee;
            return null;
        }

        public async Task<bool> PasswordSignInAsync(LogInRequest logInRequest)
        {
            var findedUser = FindEmployeeByEmail(logInRequest.Email);
            if (findedUser == null)
                return false;
            var result = await _signInManager.PasswordSignInAsync(findedUser, logInRequest.Password, logInRequest.RememberMe, false);
            if(result.Succeeded)
                return true;
            return false;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
