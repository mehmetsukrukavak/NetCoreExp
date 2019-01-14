using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreExp.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="Parola Gerekli")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Gerekli")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "E-Mail Gerekli")]
        public string Email { get; set; }
    }
}
