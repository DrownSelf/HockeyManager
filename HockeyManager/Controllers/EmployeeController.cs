using HockeyManager.DataLayer;
using HockeyManager.Models;
using HockeyManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyManager.Controllers
{
    [Authorize(Roles = "admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServise _employeeService;
        private readonly IEmployeeRoleService _employeeRoleService;

        public EmployeeController(IEmployeeServise userManager, IEmployeeRoleService employeeRoleService)
        {
            _employeeService = userManager;
            _employeeRoleService = employeeRoleService;
        }

        [HttpGet]
        public async Task<IActionResult> Manager()
        {
            List<UserRoles> userRoles = new List<UserRoles>();
            IEnumerable<Employee> employees = _employeeService.Employees;
            foreach (var employee in employees)
            {
                IList<string> role = await _employeeRoleService.GetRolesOfEmployeeAsync(employee);
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
                var result = await _employeeService.CreateEmployeeAsync(createRequest);
                if (result)
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

        [Authorize(Roles = "admin")]
        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(ChangeEmployeeRequest changeEmployeeRequest)
        {
            if (!ModelState.IsValid)
                return View(changeEmployeeRequest);
            var result = await _employeeService.UpdateEmployeeAsync(changeEmployeeRequest);
            if (result)
                return Ok();
            return BadRequest(result);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _employeeService.DeleteEmployeeAsync(id);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}