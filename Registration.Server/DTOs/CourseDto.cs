namespace Registration.Server.DTOs
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreditHours { get; set; }
        public int? DependentOnCourseID { get; set; }
        public int DepartmentId { get; set; }
    }
}
