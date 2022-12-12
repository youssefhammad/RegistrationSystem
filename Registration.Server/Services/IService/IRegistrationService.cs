using Microsoft.AspNetCore.Mvc;
using Registration.Server.DTOs;
using Registration.Shared.Models;

namespace Registration.Server.Services.IService
{
    public interface IRegistrationService
    {
        Task<IEnumerable<Course>> GetListOfFinishedCourses(int studentId);
        Task<IEnumerable<Course>> GetListOfAllCourses();
        Task<IEnumerable<Course>> GetListOfUNFinishedCourses(int studentid);
        Task<IEnumerable<Course>> GetListOfCoursesByIds(List<int> courseIds);
        Task<IEnumerable<Course>> GetListOfAvailableCourses(int studentId);
        Task<IEnumerable<Lecturer>> GetLecturerListOFCourse(int courseid);
        Task<IEnumerable<int>> GetDaySlotByCourseAndLecturer(int courseid, int lecturerid);
        Task<int> GetLectrurerCourseID(int courseId, int lecturerId, int slotPerDayId);
        Task<List<int>> CheckTimeConflict(List<int> LecCourIds);
        Task<bool> CheckTimeConflictStage2(List<int> timeslotsIds);
        Task<bool> GetListOfCreditHoursForSelectedCourses(List<int> courslecids);
        Task<bool> CheckCapacity(int courselecId);
        Task<bool> AddRegistration(int studentId,
           List<int> CoursePerLecturerIds);
        Task<IEnumerable<SchduleDto>> ViewSchedule
            (int studentid, DateTime startdate, DateTime enddate);
    }
}
