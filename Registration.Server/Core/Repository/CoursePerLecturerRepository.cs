using Microsoft.EntityFrameworkCore;
using Registration.Server.Core.IRepository;
using Registration.Server.Data;
using Registration.Server.DTOs;
using Registration.Shared.Models;

namespace Registration.Server.Core.Repository
{
    public class CoursePerLecturerRepository : GenericRepository<CoursePerLecturer>,
        ICoursePerLecturerRepository
    {
        public CoursePerLecturerRepository(ApplicationDbContext context,
            ILogger logger) : base(context, logger)
        {
        }

        public async Task<TimeOfLectureDetails> GetDayAndSlot(int courseId, int LecturerId)
        {
            
            TimeOfLectureDetails timeDetails = new TimeOfLectureDetails();
            timeDetails = await _dbSet.Where(a => a.CourseId == courseId && a.LecturerId == LecturerId).
                Include(b => b.DayPerSlot).Select(c => new TimeOfLectureDetails
                {
                    Day = c.DayPerSlot.Day.DayName,
                    StartTime = c.DayPerSlot.Slot.StartTime,
                    EndTime = c.DayPerSlot.Slot.EndTime
                }).FirstOrDefaultAsync();

            if(timeDetails == null)
            {
                return new TimeOfLectureDetails();
            }    
            else
            {
                return timeDetails;
            }
        }

        public async Task<CourseInfo> GetInfoByCourseLecId(int courseLecId)
        {
            CourseInfo courseInfo = new CourseInfo();
            courseInfo = await _dbSet.Where(a => a.Id == courseLecId).
                Include(a => a.Course).
                Include(b => b.Lecturer).
                Include(c => c.DayPerSlot).
                Select(d => new CourseInfo
                {
                    CourseName = d.Course.Name,
                    LecturerName = d.Lecturer.FullName,
                    Day = d.DayPerSlot.Day.DayName,
                    StartTime = d.DayPerSlot.Slot.StartTime,
                    EndTime = d.DayPerSlot.Slot.EndTime
                }).FirstOrDefaultAsync();

            return courseInfo;
        }
    }
}
