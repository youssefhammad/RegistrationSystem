using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Shared.AuthModels
{
    public class LoginModel
    {
        [Required]
        public int RegistrationId { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public bool IsAdmin { get; set; }

        public bool RememberMe { get; set; }
    }
}
