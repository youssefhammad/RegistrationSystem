namespace Registration.Server.DTOs
{
    public class TimeOfLectureDetails
    {
        public string Day { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
