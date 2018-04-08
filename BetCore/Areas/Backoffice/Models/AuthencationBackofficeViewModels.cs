using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BetCore.Areas.Backoffice.Models
{
    public class AuthencationBackofficeLoginViewModel
    {
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Login obligatoire")]
        public string Login { get; set; }

        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Mot de passe obligatoire")]
        public string Password { get; set; }
    }
}
