namespace Registration.Server.DTOs
{
    public class CourseInfo
    {
        public string CourseName { get; set; }
        public string LecturerName { get; set; }
        public string Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
