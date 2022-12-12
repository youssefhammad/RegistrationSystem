using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Shared.Models
{
    public class Lecturer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public ICollection<CoursePerLecturer> CoursePerLecturers { get; set; }
    }
}
