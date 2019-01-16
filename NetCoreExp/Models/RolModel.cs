using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace NetCoreExp.Models
{
    public class RolDetails
    {
        public IdentityRole Rol { get; set; }

        public IEnumerable<ApplicationUser> Members { get; set; }
        public IEnumerable<ApplicationUser> NonMembers { get; set; }
    }

    public class RolEditModel
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public string[] IdsToAdd { get; set; }
        public string[] IdsToDelete { get; set; }

    }
}
