using Microsoft.AspNetCore.Identity;
using NetCoreExp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreExp.infrastructure
{
    public class CustomPasswordValidator : IPasswordValidator<ApplicationUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<ApplicationUser> manager, ApplicationUser user, string password)
        {
            List<IdentityError> errors = new List<IdentityError>();

            if (password.ToLower().Contains(user.UserName.ToLower()))
            {
                errors.Add(new IdentityError()
                {
                    Code = "ParolaContainsUserName",
                    Description = "Parola, Kullanıcı Adı İçeremez"
                });
            }

            return Task.FromResult(errors.Count == 0 ?
                IdentityResult.Success :
                IdentityResult.Failed(errors.ToArray()));
        }
    }
}
