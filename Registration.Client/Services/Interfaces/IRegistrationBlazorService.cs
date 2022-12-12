using Registration.Client.BlazorDto;
using Registration.Shared.Models;

namespace Registration.Client.Services.Interfaces
{
    public interface IRegistrationBlazorService
    {
        Task<IEnumerable<Course>> GetListOfAvailableCourses(int studentId);
        Task<IEnumerable<Lecturer>> GetLecturerListOFCourse(int courseid);
        Task<IEnumerable<int>> GetDaySlotByCourseAndLecturer(int courseid, int lecturerid);
        Task<int> GetLectrurerCourseID(int courseId, int lecturerId, int slotPerDayId);
        Task<bool> AddRegistration(int studentId, List<int> CoursePerLecturerIds);
        Task<PermissionDto> GetLastPermissionTime();
        Task<StudentDto> GetStudentByUserID(string userId);
    }
}
