using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCoreExp.Models;
using System.Threading.Tasks;

namespace NetCoreExp.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private IPasswordValidator<ApplicationUser> passwordValidator;
        private IPasswordHasher<ApplicationUser> passwordHasher;

        public AdminController(UserManager<ApplicationUser> _userManager,
            IPasswordValidator<ApplicationUser> _passwordValidator,
            IPasswordHasher<ApplicationUser> _passwordHasher)
        {
            userManager = _userManager;
            passwordValidator = _passwordValidator;
            passwordHasher = _passwordHasher;
        }
        public IActionResult Index()
        {
            return View(userManager.Users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = model.UserName,
                    Email = model.Email
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    foreach (var item in result.Errors)
                        ModelState.AddModelError("", item.Description);
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);

            if (user != null)
            {
                var result = await userManager.DeleteAsync(user);

                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    foreach (var item in result.Errors)
                        ModelState.AddModelError("", item.Description);
            }
            else
                ModelState.AddModelError("", "Kullanıcı Bulunamadı");

            return View("Index", userManager.Users);
        }

        [HttpGet]
        public async Task<IActionResult> Update(string Id)
        {
            var user = await userManager.FindByIdAsync(Id);

            if (user != null)
                return View(user);
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Update(string Id, string Password, string UserName, string Email)
        {
            var user = await userManager.FindByIdAsync(Id);

            if (user != null)
            {
                user.Email = Email;
                user.UserName = UserName;
                IdentityResult validPassword = null;

                if (!string.IsNullOrEmpty(Password))
                {
                    validPassword = await passwordValidator.ValidateAsync(userManager, user, Password);


                    if (validPassword.Succeeded)

                        user.PasswordHash = passwordHasher.HashPassword(user, Password);

                    else
                        foreach (var item in validPassword.Errors)
                            ModelState.AddModelError("", item.Description);

                    if (validPassword.Succeeded)
                    {
                        var result = await userManager.UpdateAsync(user);

                        if (result.Succeeded)
                            return RedirectToAction("Index");
                        else
                            foreach (var item in result.Errors)
                                ModelState.AddModelError("", item.Description);
                    }
                }
                else
                    ModelState.AddModelError("", "Parola girilmeli");

            }
            else
                ModelState.AddModelError("", "Kullanıcı Bulunamadı");

            return View(user);
        }
    }
}
