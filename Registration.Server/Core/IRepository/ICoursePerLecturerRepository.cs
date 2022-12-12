using Registration.Server.DTOs;
using Registration.Shared.Models;

namespace Registration.Server.Core.IRepository
{
    public interface ICoursePerLecturerRepository : IGenericRepository<CoursePerLecturer>
    {
        //function for displaying only day time details
        Task<TimeOfLectureDetails> GetDayAndSlot(int courseId, int LecturerId);
        Task<CourseInfo> GetInfoByCourseLecId(int courseLecId);
    }
}
