namespace Registration.Server.DTOs
{
    public class SchduleDto
    {
        public string CourseName { get; set; }
        public string LecturerName { get; set; }
        public string Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int DayTimelotId { get; set; }
    }
}
