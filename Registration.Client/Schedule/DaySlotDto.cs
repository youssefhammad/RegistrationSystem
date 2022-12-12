namespace Registration.Client.Schedule
{
    public class DaySlotDto
    {
        public int Id { get; set; }
        public string LecName { get; set; }
        public string CourseName { get; set; }
        public SlotDto Slot { get; set; }
        public DayDto Day { get; set; }

    }
}
