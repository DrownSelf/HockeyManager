using HockeyManager.DataLayer;
using HockeyManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyManager.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly UserManager<Employee> _userManager;

        public EmployeeController(UserManager<Employee> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Manager()
        {
            List<UserRoles> userRoles = new List<UserRoles>();
            List<Employee> employees = _userManager.Users.ToList();
            foreach (var employee in employees)
            {
                IList<string> role = await _userManager.GetRolesAsync(employee);
                userRoles.Add(new UserRoles()
                    {
                        Roles = role,
                        USDSalary = employee.USDSallary,
                        UserEmail = employee.Email,
                        UserId = employee.Id
                    }
                );
            }
            return View(userRoles);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateEmployeeRequest createRequest)
        {
            if (ModelState.IsValid)
            {
                var newEmployee = new Employee
                {
                    Email = createRequest.Email,
                    USDSallary = createRequest.USDSalary,
                    UserName = createRequest.Email
                };
                var result = await _userManager.CreateAsync(newEmployee, createRequest.Password);
                if (result.Succeeded)
                    return RedirectToAction("Manager", "Employee");
                ModelState.AddModelError("", "Something wrong happened");
            }
            return View(createRequest);
        }

        [HttpGet]
        public IActionResult Update()
        {
            return View();
        }

        [Authorize (Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(ChangeEmployeeRequest changeEmployeeRequest)
        {
            if (ModelState.IsValid)
            {
                var findedUser = await _userManager.FindByIdAsync(changeEmployeeRequest.EmployeeId);
                if (findedUser != null)
                {
                    findedUser.Email = changeEmployeeRequest.Email;
                    findedUser.USDSallary = changeEmployeeRequest.USDSalary;
                    await _userManager.UpdateAsync(findedUser);
                    return RedirectToAction("Manager", "Employee");
                }
                ModelState.AddModelError("", "User haven't found");
            }
            return View(changeEmployeeRequest);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var findedEmployee = await _userManager.FindByIdAsync(id);
            if (findedEmployee != null)
            {
                var result = await _userManager.DeleteAsync(findedEmployee);
                if (result.Succeeded)
                    return RedirectToAction("Manager", "Employee");
                ModelState.AddModelError("", "This user is not existing");
            }
            return RedirectToAction("Manager", "Employee");
        }
    }
}