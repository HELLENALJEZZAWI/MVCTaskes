using loginandregester.Models;
using loginandregester.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace loginandregester.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser>signInManager;
        private readonly UserManager<AppUser>userManger;
        public AccountController(SignInManager<AppUser>signInManager, UserManager<AppUser> userManger)
        {
            this.signInManager = signInManager;
            this.userManger = userManger;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Login(LoginVM model)
        {
            if (ModelState.IsValid) 
            {
                var result = await signInManager.PasswordSignInAsync(model.Username!, model.Password!, model.RemmemberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid login attemp");
                return View(model);
            }

            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new()
                {
                    Name = model.Name,
                    UserName = model.Email,
                    Email = model.Email,
                    Adress = model.Adress
                };
                var result = await userManger.CreateAsync(user, model.Password!);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);               }
            }
            return View(model);
        }
        public async Task <IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
