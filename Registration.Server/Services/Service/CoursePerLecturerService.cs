using Registration.Server.Core.IConfiguration;
using Registration.Server.DTOs;
using Registration.Server.Services.IService;

namespace Registration.Server.Services.Service
{
    public class CoursePerLecturerService : ICoursePerLecturerService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CoursePerLecturerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<TimeOfLectureDetails> GetDayAndSlot(int courseId, int LecturerId)
        {
            return await _unitOfWork.CoursesPerLecturers.GetDayAndSlot(courseId, LecturerId);
        }

        public async Task<CourseInfo> GetInfoByCourseLecId(int courseLecId)
        {
            return await _unitOfWork.CoursesPerLecturers.GetInfoByCourseLecId(courseLecId);
        }
    }
}
