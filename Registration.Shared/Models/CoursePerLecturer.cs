using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Shared.Models
{
    public class CoursePerLecturer
    {
        public int Id { get; set; }
        public int Capacity { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public int LecturerId { get; set; }
        public Lecturer Lecturer { get; set; }
        public int DayPerSlotId { get; set; }
        public DayPerSlot DayPerSlot { get; set; }
        public List<RegistrationTable> Registrations { get; set; }
    }
}
