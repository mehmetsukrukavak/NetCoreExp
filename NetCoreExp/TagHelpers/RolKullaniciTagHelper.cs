using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Razor.TagHelpers;
using NetCoreExp.Models;

namespace NetCoreExp.TagHelpers
{
    [HtmlTargetElement("td", Attributes = "identity-role")]
    public class RolKullaniciTagHelper : TagHelper
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<IdentityRole> roleManager;

        public RolKullaniciTagHelper(UserManager<ApplicationUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            userManager = _userManager;
            roleManager = _roleManager;
        }

        [HtmlAttributeName("identity-rol")]
        public string Role { get; set; }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            List<string> names = new List<string>();

            var role = await roleManager.FindByIdAsync(Role);

            if (role != null)
                foreach (var user in userManager.Users)
                    if (user != null && await userManager.IsInRoleAsync(user, role.Name))
                        names.Add(user.UserName);

            output.Content.SetContent(names.Count == 0 ?
            "Kullanıcı Yok" :
                string.Join(", ", names));
        }
    }
}
