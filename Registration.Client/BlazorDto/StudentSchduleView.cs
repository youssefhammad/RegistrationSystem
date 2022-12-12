namespace Registration.Client.BlazorDto
{
    public class StudentSchduleView
    {
        public string CourseName { get; set; }
        public string LecturerName { get; set; }
        public string Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int DayTimelotId { get; set; }
    }
}
