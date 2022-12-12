using Registration.Server.Core.IConfiguration;
using Registration.Server.DTOs;
using Registration.Server.Services.IService;
using Registration.Shared.Models;

namespace Registration.Server.Services.Service
{
    public class RegistrationService : IRegistrationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegistrationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Course>> GetListOfAllCourses()
        {
            return await _unitOfWork.Registrations.GetListOfAllCourses();
        }

        //Last step
        public async Task<IEnumerable<Course>> GetListOfAvailableCourses(int studentId)
        {
            var ListOfFinishedCourses = await GetListOfFinishedCourses(studentId);
            var ListOdUnfinishedCourses = await GetListOfUNFinishedCourses(studentId);

            List<int> temp = new List<int>();
            List<int> fineshedcoursesIds = new List<int>();
            foreach (var finished in ListOfFinishedCourses)
            {
                fineshedcoursesIds.Add(finished.Id);
            }
            foreach(var unfinishedcourse in ListOdUnfinishedCourses)
            {
                if(unfinishedcourse.DependentOnCourseID ==null ||
                    fineshedcoursesIds.Contains(unfinishedcourse.DependentOnCourseID.Value))
                {
                    temp.Add(unfinishedcourse.Id);
                }
            }
            IEnumerable<Course> ListOfAvailableCourses = new List<Course>();
            ListOfAvailableCourses = await GetListOfCoursesByIds(temp);
            return ListOfAvailableCourses;
        }

        public Task<IEnumerable<Course>> GetListOfCoursesByIds(List<int> courseIds)
        {
            return _unitOfWork.Registrations.GetListOfCoursesByIds(courseIds);
        }

        public async Task<IEnumerable<Course>> GetListOfFinishedCourses(int studentId)
        {
            return await _unitOfWork.Registrations.GetListOfFinishedCourses(studentId);
        }

        public async Task<IEnumerable<Course>> GetListOfUNFinishedCourses(int studentid)
        {
            var listofCourses = await GetListOfAllCourses();
            var finishedCourses = await GetListOfFinishedCourses(studentid);
            IEnumerable<Course> unfinishedCourses = new List<Course>();
            List<Course> temp = new List<Course>();

            var idsOfListOfAllCourses = listofCourses.Select(a => a.Id).ToList();
            var idsOfListOfFinishedCourses = finishedCourses.Select(a => a.Id).ToList();

            var idsofUfinishedCourses = idsOfListOfAllCourses.
                Except(idsOfListOfFinishedCourses).ToList();
            
            unfinishedCourses = await GetListOfCoursesByIds(idsofUfinishedCourses);
            return unfinishedCourses;

        }


        public async Task<IEnumerable<Lecturer>> GetLecturerListOFCourse(int courseid)
        {
            return await _unitOfWork.Registrations.GetLecturerListOFCourse(courseid);
        }

        public Task<IEnumerable<int>> GetDaySlotByCourseAndLecturer(int courseid, int lecturerid)
        {
            return _unitOfWork.Registrations.GetDaySlotByCourseAndLecturer(courseid, lecturerid);
        }

        public async Task<int> GetLectrurerCourseID(int courseId, int lecturerId, int slotPerDayId)
        {
            return await _unitOfWork.Registrations.GetLectrurerCourseID(courseId, lecturerId, slotPerDayId);
        }

        //check for timeconflict
        public async Task<List<int>> CheckTimeConflict(List<int> LecCourIds)
        {
            List<int> slotsperday = await _unitOfWork.Registrations.
                CheckTimeConflict(LecCourIds);
            return slotsperday;
        }
        public async Task<bool> CheckTimeConflictStage2(List<int> timeslotsIds)
        {
            //List<int> list = await _unitOfWork.Registrations.CheckTimeConflict(timeslotsIds);
            //IEnumerable<int> duplicates = timeslotsIds.GroupBy(x => x)
            //                            .Where(g => g.Count() > 1)
            //                            .Select(x => x.Key);
            bool result;
            if (timeslotsIds.Count != timeslotsIds.Distinct().Count())
            {
                // Duplicates exist
                result = false;
                return result;
            }
            else
            {
                result=true;
                return result;

            }
        }

        //check for class capacity
        public async Task<bool> CheckCapacity(int courselecId)
        {
            int capacityForClass = 
                await _unitOfWork.Registrations.GetCapacityForClassById(courselecId);
            int actualCapacityOfClass =
            await _unitOfWork.Registrations.GetActualCapacity(courselecId);

            if(actualCapacityOfClass < capacityForClass)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public async Task<bool> GetListOfCreditHoursForSelectedCourses(List<int> courslecids)
        {
            var res = await _unitOfWork.Registrations.
                GetListOfCreditHoursForSelectedCourses(courslecids);
            int SumOfCreditHours = res.Sum();
            if(SumOfCreditHours <= 18)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> AddRegistration(int studentId,List<int> CoursePerLecturerIds)
        {
            var result = await _unitOfWork.Registrations.
                AddRegistration(studentId, CoursePerLecturerIds);

            return result;
        }

        public async Task<IEnumerable<SchduleDto>> ViewSchedule
            (int studentid, DateTime startdate, DateTime enddate)
        {
            List<SchduleDto> coursesinfo = new List<SchduleDto>();
            
            var s = await _unitOfWork.Registrations.ViewSchedule
                (studentid, startdate, enddate);
            
            foreach(var courseinfo in s)
            {
                SchduleDto info = new SchduleDto()
                {
                    CourseName = courseinfo.CoursePerLecturer.Course.Name,
                    LecturerName = courseinfo.CoursePerLecturer.Lecturer.FullName,
                    Day = courseinfo.CoursePerLecturer.DayPerSlot.Day.DayName,
                    StartTime = courseinfo.CoursePerLecturer.DayPerSlot.Slot.StartTime,
                    EndTime = courseinfo.CoursePerLecturer.DayPerSlot.Slot.EndTime,
                    DayTimelotId = courseinfo.CoursePerLecturer.DayPerSlot.Id
                };
                coursesinfo.Add(info);
            }
            return coursesinfo;
        }
    }
}
