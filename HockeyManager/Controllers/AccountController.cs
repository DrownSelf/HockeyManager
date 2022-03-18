using HockeyManager.DataLayer;
using HockeyManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HockeyManager.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<Employee> _userManager;
        private readonly SignInManager<Employee> _signInManager;

        public AccountController(UserManager<Employee> userManager, SignInManager<Employee> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
                var newEmployee = new Employee();
                newEmployee.Email = registerRequest.Email;
                newEmployee.UserName = registerRequest.Email;
                var result = await _userManager.CreateAsync(newEmployee, registerRequest.Password);

                if (result.Succeeded)
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
                var findedUser = await _userManager.FindByEmailAsync(logInRequest.Email);
                var result = await
                    _signInManager.PasswordSignInAsync(findedUser, logInRequest.Password, logInRequest.RememberMe, false);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
                
                ModelState.AddModelError("", "Wrong Email or password");
            }
            return View(logInRequest);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}