
using Bilet_1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    public class AcountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public AcountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registervm)
        {
            if (!ModelState.IsValid) return View(registervm);

            if (registervm.Password != registervm.RepeatPassword)
            {
                ModelState.AddModelError(string.Empty, "Passwords do not match!");
                return View(registervm);
            }

            AppUser user = new()
            {
                Name = registervm.Name,
                Surname = registervm.Surname,
                Email = registervm.Email,

            };

            var result = await _userManager.CreateAsync(user, registervm.Password);
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View(registervm);
            }

            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Logout()
        {
            return View();
        }
    }
}