using Registration.Server.DTOs;

namespace Registration.Server.Services.IService
{
    public interface ICoursePerLecturerService
    {
        Task<TimeOfLectureDetails> GetDayAndSlot(int courseId, int LecturerId);
        Task<CourseInfo> GetInfoByCourseLecId(int courseLecId);
    }
}
