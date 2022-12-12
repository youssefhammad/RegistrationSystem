using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Shared.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string FullName { get; set; }
        public ICollection<Permission> Permissions { get; set; }
    }
}
