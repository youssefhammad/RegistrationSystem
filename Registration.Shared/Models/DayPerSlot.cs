using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Shared.Models
{
    public class DayPerSlot
    {
        public int Id { get; set; }
        public int SlotId { get; set; }
        public Slot Slot { get; set; }
        public int DayId { get; set; }
        public Day Day { get; set; }
        public ICollection<CoursePerLecturer> CoursesLectures { get; set; }
    }
}
