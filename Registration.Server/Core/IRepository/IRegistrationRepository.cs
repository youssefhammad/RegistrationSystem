using Microsoft.AspNetCore.Mvc;
using Registration.Shared.Models;

namespace Registration.Server.Core.IRepository
{
    public interface IRegistrationRepository : IGenericRepository<RegistrationTable>
    {
        Task<IEnumerable<Course>> GetListOfFinishedCourses(int studentId);
        Task<IEnumerable<Course>> GetListOfAllCourses();
        Task<IEnumerable<Course>> GetListOfCoursesByIds(List<int> courseIds);
        Task<IEnumerable<Lecturer>> GetLecturerListOFCourse(int courseid);
        Task<IEnumerable<int>> GetDaySlotByCourseAndLecturer(int courseid, int lecturerid);
        Task<int> GetLectrurerCourseID(int courseId, int lecturerId, int slotPerDayId);
        Task<List<int>> CheckTimeConflict(List<int> LecCourIds);
        Task<int> GetCapacityForClassById(int courselecId);
        Task<List<int>> GetListOfCreditHoursForSelectedCourses(List<int> courselecIds);
        Task<int> GetActualCapacity(int id);
        Task<bool> AddRegistration(int studentId,
            List<int> CoursePerLecturerIds);
        Task<IEnumerable<RegistrationTable>> ViewSchedule
            (int studentid,DateTime startdate, DateTime enddate);

    }
}
