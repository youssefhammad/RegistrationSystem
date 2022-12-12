using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registration.Shared.Models
{
    public class RegistrationTable
    {
        public int Id { get; set; }
        public int? StudentId { get; set; }
        public Student? Student { get; set; }
        public int CoursePerlecturerId { get; set; }
        public CoursePerLecturer CoursePerLecturer { get; set; }
 
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime RegistrationTime { get; set; }

    }
}
