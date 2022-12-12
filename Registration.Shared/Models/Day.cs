using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Shared.Models
{
    public class Day
    {
        public int Id { get; set; }
        public string DayName { get; set; }
        public ICollection<DayPerSlot> DaysPerSlot { get; set; }
    }
}
