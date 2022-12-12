using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Registration.Server.Core.IRepository;
using Registration.Server.Data;
using Registration.Shared.Models;

namespace Registration.Server.Core.Repository
{
    public class RegistrationRepository : GenericRepository<RegistrationTable>,
        IRegistrationRepository
    {
        public RegistrationRepository(ApplicationDbContext context, ILogger logger) : base(context, logger)
        {
        }

        //step 1
        public async Task<IEnumerable<Course>> GetListOfFinishedCourses(int studentId)
        {
            var regtabforStudent = await _dbSet.Where(c => c.StudentId == studentId).
                Include(a => a.CoursePerLecturer.Course).ToListAsync();
            List<Course> courses = new List<Course>();
            foreach (var reg in regtabforStudent)
            {
                Course course = new Course()
                {
                    Id = reg.CoursePerLecturer.Course.Id,
                    Name = reg.CoursePerLecturer.Course.Name,
                    DependentOnCourseID = reg.CoursePerLecturer.Course.DependentOnCourseID
                };
                courses.Add(course);
            }
            return courses;
        }


        //step2
        public async Task<IEnumerable<Course>> GetListOfAllCourses()
        {
            List<Course> courseList = new List<Course>();
            courseList = await _context.Courses.Select(a => new Course
            {
                Id = a.Id,
                Name = a.Name,
                CreditHours = a.CreditHours,
                DepartmentId = a.DepartmentId,
                DependentOnCourseID = a.DependentOnCourseID,

            }).ToListAsync();

            return courseList;
        }


        public async Task<IEnumerable<Course>> GetListOfCoursesByIds(List<int> courseIds)
        {
            List<Course> courseList = new List<Course>();
            foreach (int id in courseIds)
            {
                var courseitem = await _context.Courses.Where(a => a.Id == id).
                    Select(a => new Course
                    {
                        Id = a.Id,
                        Name = a.Name,
                        CreditHours = a.CreditHours,
                        DepartmentId = a.DepartmentId,
                        DependentOnCourseID = a.DependentOnCourseID,


                    }).FirstOrDefaultAsync();

                courseList.Add(courseitem);
            }
            return courseList;
        }

        //list of lectrur for specific course
        public async Task<IEnumerable<Lecturer>> GetLecturerListOFCourse(int courseid)
        {
            var lecturerList = await _context.CoursePerLecturers.Where(a => a.CourseId == courseid).
                Include(b => b.Lecturer).ToListAsync();
            List<Lecturer> lecturersforCourse = new List<Lecturer>();
            foreach (var lecturer in lecturerList)
            {
                Lecturer lecturer1 = new Lecturer()
                {
                    Id = lecturer.Lecturer.Id,
                    FullName = lecturer.Lecturer.FullName
                };
                lecturersforCourse.Add(lecturer1);
            }
            return lecturersforCourse;
        }

        public async Task<IEnumerable<int>> GetDaySlotByCourseAndLecturer(int courseid, int lecturerid)
        {
            var slotId = await _context.CoursePerLecturers.Where(a => a.CourseId == courseid
            && a.LecturerId == lecturerid).Select(b => b.DayPerSlotId).ToListAsync();
            return slotId;
        }

        //get LecturerMtoMCourses id by cID lID sPERdID 
        public async Task<int> GetLectrurerCourseID(int courseId, int lecturerId, int slotPerDayId)
        {
            var lecIdCourseId = await _context.CoursePerLecturers.
                Where(a => a.CourseId == courseId &&
                a.LecturerId == lecturerId &&
                a.DayPerSlotId == slotPerDayId).FirstOrDefaultAsync();

            return lecIdCourseId == null ? 0 : lecIdCourseId.Id;
        }


        //is no conflict with any other course time
        public async Task<List<int>> CheckTimeConflict(List<int> LecCourIds)
        {
            List<int> ListOfTimeSlots = new List<int>();
            foreach (var id in LecCourIds)
            {
                var TimeSlot =
                    await _context.CoursePerLecturers.Where(s=> s.Id == id)
                    .Select(a => a.DayPerSlotId).
                    FirstOrDefaultAsync();
                ListOfTimeSlots.Add(TimeSlot);
            }

            return ListOfTimeSlots;
        }

        public async Task<int> GetCapacityForClassById(int courselecId)
        {
            int capacity = await _context.CoursePerLecturers
                .Where(a => a.Id == courselecId).
                Select(a => a.Capacity).FirstOrDefaultAsync();

            return capacity;
        }

        public async Task<int> GetActualCapacity(int id)
        {
            var s = await _context.Registrations.Where
                (c => c.CoursePerlecturerId == id).Select(s => s.CoursePerlecturerId)
                .ToListAsync();
            int count = s.Count();
            return count;
        }


        public async Task<List<int>> GetListOfCreditHoursForSelectedCourses(List<int> courselecIds)
        {
            List<int> CHlist = new List<int>();
            foreach (var id in courselecIds)
            {
                var oneitemCH = await _context.CoursePerLecturers.Where(x => x.Id == id).
                    Include(a => a.Course).
                    Select(b => b.Course.CreditHours).FirstOrDefaultAsync();
                CHlist.Add(oneitemCH);
            }
            return CHlist;
        }

        //Add New Registration
        public async Task<bool> AddRegistration(int studentId,
            List<int> CoursePerLecturerIds)
        {
            foreach (var cPl in CoursePerLecturerIds)
            {
                await _dbSet.AddAsync(new RegistrationTable
                {
                    StudentId = studentId,
                    CoursePerlecturerId = cPl,
                });
            }

            return true;
        }

        public async Task<IEnumerable<RegistrationTable>> ViewSchedule(int studentid, DateTime startdate, DateTime enddate)
        {
             List<RegistrationTable> s = await _context.Registrations.
                Include(l => l.CoursePerLecturer).
                Include(w=> w.CoursePerLecturer.Course).
                Include(p=> p.CoursePerLecturer.Lecturer).
                Include(e=> e.CoursePerLecturer.DayPerSlot.Slot).
                Include(f=> f.CoursePerLecturer.DayPerSlot.Day).
                Where(a => a.StudentId == studentid &&
             startdate < a.RegistrationTime && a.RegistrationTime < enddate).
             ToListAsync();
            return s;
            
        }
    }
}
