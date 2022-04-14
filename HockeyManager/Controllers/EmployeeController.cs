using HockeyManager.DataLayer;
using HockeyManager.Models;
using HockeyManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HockeyManager.Controllers
{
    [Authorize(Roles = "admin")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeServise _employeeService;
        private readonly IEmployeeRoleService _employeeRoleService;

        public EmployeeController(IEmployeeServise employeeService, IEmployeeRoleService employeeRoleService)
        {
            _employeeService = employeeService;
            _employeeRoleService = employeeRoleService;
        }

        [HttpGet]
        public async Task<IActionResult> Manager()
        {
            List<UserRoles> userRoles = new List<UserRoles>();
            IEnumerable<Employee> employees = _employeeService.Employees;
            foreach (var employee in employees)
            {
                IList<string> roles = await _employeeRoleService.GetRolesOfEmployeeAsync(employee);
                userRoles.Add(new UserRoles()
                {
                    Roles = roles,
                    UserEmail = employee.Email,
                    UserId = employee.Id
                }
                );
            }
            return View(userRoles);
        }

        [HttpGet]
        public IActionResult CreateEmployee()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(CreateEmployeeRequest createRequest)
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

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _employeeService.DeleteEmployeeAsync(id, _employeeRoleService);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}