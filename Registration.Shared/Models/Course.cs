using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Shared.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreditHours { get; set; }
        public int? DependentOnCourseID { get; set; }
        public Course? DependentCourse { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public ICollection<CoursePerLecturer> CoursePerLecturers { get; set; }
    }
}
