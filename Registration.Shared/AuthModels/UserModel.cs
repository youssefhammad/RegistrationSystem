using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Shared.AuthModels
{
    public  class UserModel
    {
        public string Email { get; set; }
        public bool IsAuthenticated { get; set; }
    }
}
