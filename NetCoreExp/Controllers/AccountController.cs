using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCoreExp.Models;
using System.Threading.Tasks;

namespace NetCoreExp.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private SignInManager<ApplicationUser> signInManager;
        private UserManager<ApplicationUser> userManager;

        public AccountController(SignInManager<ApplicationUser> _signInManager,
                                UserManager<ApplicationUser> _userManager)
        {
            signInManager = _signInManager;
            userManager = _userManager;
        }
        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(SignInModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

                    if (result.Succeeded)
                        return Redirect(returnUrl ?? "/");
                }

                ModelState.AddModelError("LoginError", "Email yada Parola Hatalı");
            }
            return View(model);
        }

        public async Task<IActionResult> Logout(string returnUrl)
        {

            await signInManager.SignOutAsync();

            return Redirect(returnUrl ?? "/");

        }
    }
}