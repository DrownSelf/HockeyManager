using HockeyManager.Models;
using HockeyManager.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace HockeyManager.Controllers
{
    [Authorize(Roles = "admin")]
    public class RolesController : Controller
    {
        private readonly IRoleService _roleService;
        private readonly IEmployeeRoleService _employeeRoleService;

        public RolesController(IRoleService roleManager, IEmployeeRoleService employeeRoleService)
        {
            _roleService = roleManager;
            _employeeRoleService = employeeRoleService;
        }

        [HttpGet]
        public IActionResult RolesManager()
        {
            return View(_roleService.Roles.ToList());
        }
        
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string name)
        {
            if (ModelState.IsValid)
            {
                var newRole = await _roleService.CreateRoleAsync(name);
                if (newRole)
                    return Ok();
                return BadRequest();
            }
            return View(name);
        }

        [HttpGet]
        public IActionResult RolesUpdate()
        {
            return View();
        }
        
        [HttpPut]
        public async Task<IActionResult> RolesUpdate(string id, string newName)
        {
            if(!ModelState.IsValid)
                return View();
            var result = await _roleService.UpdateRoleAsync(id, newName);
            if (result)
                return Ok();
            return BadRequest();
        }

        [HttpGet]
        public IActionResult EditRoleState()
        {
            return View(_roleService.Roles.ToList());
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
            var result = await _roleService.DeleteRoleAsync(id);
            if (result)
                return Ok();
            return BadRequest();
        }
    }
}