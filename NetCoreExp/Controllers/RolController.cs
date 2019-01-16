using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetCoreExp.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NetCoreExp.Controllers
{
    [Authorize(Roles="Admin")]
    public class RolController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;

        public RolController(RoleManager<IdentityRole> _roleManager, UserManager<ApplicationUser> _userManager)
        {
            roleManager = _roleManager;
            userManager = _userManager;
        }

        public IActionResult Index()
        {
            return View(roleManager.Roles);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (ModelState.IsValid)
            {
                var result = await roleManager.CreateAsync(new IdentityRole(name));

                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error.Description);

            }
            return View(name);
        }

        public async Task<IActionResult> Update(string id)
        {
            IdentityRole role = await roleManager.FindByIdAsync(id);

            var members = new List<ApplicationUser>();
            var nonmembers = new List<ApplicationUser>();

            foreach (var user in userManager.Users)
            {
                var list = await userManager.IsInRoleAsync(user, role.Name) ? members : nonmembers;

                list.Add(user);
            }

            var model = new RolDetails()
            {
                Members = members,
                NonMembers = nonmembers,
                Rol = role
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(RolEditModel model)
        {
            IdentityResult result;

            if (ModelState.IsValid)
            {
                foreach (var userId in model.IdsToAdd ?? new string[] { })
                {
                    var user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.AddToRoleAsync(user, model.RoleName);

                        if (!result.Succeeded)
                            foreach (var error in result.Errors)
                                ModelState.AddModelError("", error.Description);

                    }
                }

                foreach (var userId in model.IdsToDelete ?? new string[] { })
                {
                    var user = await userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        result = await userManager.RemoveFromRoleAsync(user, model.RoleName);

                        if (!result.Succeeded)
                            foreach (var error in result.Errors)
                                ModelState.AddModelError("", error.Description);

                    }
                }
            }

            if (ModelState.IsValid)
                return RedirectToAction("Index");
            else
                return RedirectToAction("Update", model.RoleId);
        }


        public async Task<IActionResult> Delete(string id)
        {
            var role = await roleManager.FindByIdAsync(id);

            if (role != null)
            {
                var result = await roleManager.DeleteAsync(role);

                if (result.Succeeded)
                {
                    TempData["message"] = $"{role.Name} Silindi";
                    return RedirectToAction("Index");
                }
                else
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error.Description);
            }

            return RedirectToAction("Index");
        }
    }
}
