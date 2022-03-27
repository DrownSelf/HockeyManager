using HockeyManager.DataLayer;
using HockeyManager.Models;
using HockeyManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyManager.Controllers
{
    [Authorize(Roles = "admin")]
    public class RolesController : Controller
    {
        private readonly IRoleService _roleManager;
        private readonly IEmployeeRoleService _employeeRoleService;

        public RolesController(IRoleService roleManager, IEmployeeRoleService employeeRoleService)
        {
            _roleManager = roleManager;
            _employeeRoleService = employeeRoleService;
        }

        [HttpGet]
        public IActionResult RolesManager()
        {
            return View(_roleManager.Roles);
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (ModelState.IsValid)
            {
                var newRole = await _roleManager.CreateRoleAsync(name);
                if (newRole)
                    return RedirectToAction("Index", "Employee");
                ModelState.AddModelError("", "Something wrong happened");
            }
            return View(name);
        }

        [HttpPut]
        public async Task<IActionResult> RolesUpdate(string id, string newName)
        {
            if(!ModelState.IsValid)
                return View();
            var result = await _roleManager.UpdateRoleAsync(id, newName);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpGet]
        public IActionResult EditRoleState()
        {
            return View(_roleManager.Roles);
        }

        [HttpPut]
        public async Task<IActionResult> EditRoleState(SetRoleRequest setRoleRequest)
        {
            if(!ModelState.IsValid)
                return View(setRoleRequest);
            var result = await _employeeRoleService.EditRoleState(setRoleRequest);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var result = await _roleManager.DeleteRoleAsync(id);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}