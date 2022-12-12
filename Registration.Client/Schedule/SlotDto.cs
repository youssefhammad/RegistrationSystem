namespace Registration.Client.Schedule
{
    public class SlotDto
    {
        
        public int Id { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
