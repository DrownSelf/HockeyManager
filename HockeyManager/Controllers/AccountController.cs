using HockeyManager.DataLayer;
using HockeyManager.Models;
using HockeyManager.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HockeyManager.Controllers
{
    public class AccountController : Controller
    {
        private readonly IEmployeeServise _employeeService;
        private readonly ISignInService _signInService;

        public AccountController(IEmployeeServise employeeService, ISignInService signInManager)
        {
            _employeeService = employeeService;
            _signInService = signInManager;
        }

        [HttpGet]
        public IActionResult Registr()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registr(RegisterRequest registerRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await _employeeService.RegisterEmployeeAsync(registerRequest);
                if (result)
                    return RedirectToAction("Index", "Home");
                ModelState.AddModelError("", "Something wrong happened");
            }
            return View(registerRequest);
        }

        [HttpGet]
        public IActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogIn(LogInRequest logInRequest)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInService.PasswordSignInAsync(logInRequest);
                if (result)
                    return RedirectToAction("Index", "Home");
                ModelState.AddModelError("", "Wrong Email or password");
            }
            return View(logInRequest);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInService.SignOutAsync();
            return Ok();
        }
    }
}