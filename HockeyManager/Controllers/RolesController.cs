using HockeyManager.DataLayer;
using HockeyManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyManager.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<Employee> _userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, UserManager<Employee> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
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
                var newRole = await _roleManager.CreateAsync(new IdentityRole(name));
                if (newRole.Succeeded)
                    return RedirectToAction("Index", "Employee");
                ModelState.AddModelError("", "Something wrong happened");
            }
            return View(name);
        }

        [HttpPut]
        public async Task<IActionResult> RolesUpdate(string id, string newName)
        {
            var findedRole = await _roleManager.FindByIdAsync(id);
            if(findedRole != null)
            {
                findedRole.Name = newName;
                var result = await _roleManager.UpdateAsync(findedRole);
                if (result.Succeeded)
                    return RedirectToAction("Roles");
                ModelState.AddModelError("", "Something wrong happened");
            }
            return RedirectToAction("Roles");
        }

        [HttpGet]
        public IActionResult EditRoleState()
        {
            return View(_roleManager.Roles);
        }

        [HttpPut]
        public async Task<IActionResult> EditRoleState(SetRoleRequest setRoleRequest)
        {
            var findedUser = await _userManager.FindByIdAsync(setRoleRequest.UserId);
            if (findedUser != null)
            {
                var employeeRoles = await _userManager.GetRolesAsync(findedUser);
                var deletedRoles = employeeRoles.Except(setRoleRequest.Roles);
                var addedRoles = setRoleRequest.Roles.Except(employeeRoles);

                await _userManager.AddToRolesAsync(findedUser, addedRoles);
                await _userManager.RemoveFromRolesAsync(findedUser, deletedRoles);

                return View("Roles");
            }
            return View(setRoleRequest);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRole(string id)
        {
            var findedRole = await _roleManager.FindByIdAsync(id);
            if(findedRole != null)
            {
                var result = await _roleManager.DeleteAsync(findedRole);
                if (result.Succeeded)
                    return RedirectToAction("Roles");
                ModelState.AddModelError("", "Something wrong happened");
            }
            return RedirectToAction("Roles");
        }
    }
}