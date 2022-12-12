namespace Registration.Client.BlazorDto
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int FinishedHours { get; set; }
        public decimal GPA { get; set; }
        public int DepartmentId { get; set; }
    }
}
