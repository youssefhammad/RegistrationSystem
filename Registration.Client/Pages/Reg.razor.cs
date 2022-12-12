using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Registration.Client.BlazorDto;
using Registration.Client.Schedule;
using Registration.Client.Services.Interfaces;
using Registration.Shared.Models;

namespace Registration.Client.Pages
{
    public partial class Reg
    {


        [Inject]
        public IRegistrationBlazorService? registrationBlazorService { get; set; }
        [Inject]
        public SchduleDto Schdule { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }
        [Inject]
        public AuthenticationStateProvider GetAuthenticationStateAsync { get; set; }

        public StudentDto Student { get; set; }
        public PermissionDto permission { get; set; }
        public List<Course> Courses { get; set; } = default!;
        public List<Lecturer> Lecturers { get; set; } = default!;
        public List<int> SlotIds { get; set; } = default!;
        public List<TimeOfLectureDetails> TimeOfLectureDetails { get; set; } = default!;
        public int courseId { get; set; }
        public int lecturerId { get; set; }
        public int slotId { get; set; }
        public string lecturerName { get; set; }
        public string courseName { get; set; }
        public string ErrorMessageForOverlapping { get; set; }
        public int c { get; set; }
        public List<int> ClassIds = new List<int>();
        private readonly object username;

        public bool IsPermitted { get; set; }
        public bool IsRegSuccessed { get; set; }
        public string name { get; set; }
        

        //GetListOfCourses
        protected override async Task OnInitializedAsync()
        {
            var authstate = await GetAuthenticationStateAsync.GetAuthenticationStateAsync();
            var user = authstate.User;
            this.name = user.Identity.Name;
            Student = (await registrationBlazorService.GetStudentByUserID(name));

            permission = (await registrationBlazorService.GetLastPermissionTime());
            var startdate = permission.StartDate;
            var enddate = permission.EndDate;
            DateTime date = DateTime.Now;
            if (startdate < date && date < enddate)
            {
                this.IsPermitted = true;
                Courses = (await registrationBlazorService.GetListOfAvailableCourses(Student.Id)).ToList();
                List<DaySlotDto> ss1 = new List<DaySlotDto>();
                ss1.Add(new DaySlotDto());
                ss1.Add(new DaySlotDto());
                ss1.Add(new DaySlotDto());
                ss1.Add(new DaySlotDto());
                List<List<DaySlotDto>> dd = new List<List<DaySlotDto>>();
                dd.Add(ss1);

                List<DaySlotDto> ss2 = new List<DaySlotDto>();
                ss2.Add(new DaySlotDto());
                ss2.Add(new DaySlotDto());
                ss2.Add(new DaySlotDto());
                ss2.Add(new DaySlotDto());
                dd.Add(ss2);

                List<DaySlotDto> ss3 = new List<DaySlotDto>();
                ss3.Add(new DaySlotDto());
                ss3.Add(new DaySlotDto());
                ss3.Add(new DaySlotDto());
                ss3.Add(new DaySlotDto());
                dd.Add(ss3);

                List<DaySlotDto> ss4 = new List<DaySlotDto>();
                ss4.Add(new DaySlotDto());
                ss4.Add(new DaySlotDto());
                ss4.Add(new DaySlotDto());
                ss4.Add(new DaySlotDto());
                dd.Add(ss4);

                List<DaySlotDto> ss5 = new List<DaySlotDto>();
                ss5.Add(new DaySlotDto());
                ss5.Add(new DaySlotDto());
                ss5.Add(new DaySlotDto());
                ss5.Add(new DaySlotDto());
                dd.Add(ss5);

                List<DaySlotDto> ss6 = new List<DaySlotDto>();
                ss6.Add(new DaySlotDto());
                ss6.Add(new DaySlotDto());
                ss6.Add(new DaySlotDto());
                ss6.Add(new DaySlotDto());
                dd.Add(ss6);


                Schdule.X = dd;
                foreach (var d in dd)
                {
                    foreach (var s in d)
                    {
                        s.CourseName = "Empty";
                    }
                }
            }
            else
            {
                this.IsPermitted = false;
            }
        }

        //GetListOfLectureresForCourse
        public async Task GetLecturer(ChangeEventArgs e)
        {
            this.courseName = e.Value.ToString();
            this.courseId = Courses.Where(a => a.Name == courseName).Select(a => a.Id).FirstOrDefault();
            Lecturers = (await registrationBlazorService.GetLecturerListOFCourse(courseId)).ToList();
        }

        //GetListOFSlotsIdsPerCoursesAndLEctureres
        public async Task GetSlotPerDayid(ChangeEventArgs e)
        {
            this.lecturerName = e.Value.ToString();
            this.lecturerId = Lecturers.Where(a => a.FullName == lecturerName).Select(a => a.Id).FirstOrDefault();
            SlotIds = (await registrationBlazorService.GetDaySlotByCourseAndLecturer(courseId, lecturerId)).ToList();

        }

        //PutSlotIdSelectedInpropertySlotId 
        public void PutSlotidInProp(ChangeEventArgs e)
        {
            Lecturers.Clear();
            SlotIds.Clear();
            this.slotId = int.Parse(string.Format("{0}", e.Value));
            Console.WriteLine($"Course ID = {courseId}" +
                $"LecturerId ={lecturerId}" +
                $"slotId = {slotId}");

        }

        public async Task GetClassID()
        {
            courseId = (await registrationBlazorService.GetLectrurerCourseID(
                courseId, lecturerId, slotId));
            Console.WriteLine(courseId);

            Console.WriteLine(ClassIds);
            foreach (var id in ClassIds)
            {
                Console.WriteLine(id);
            }
            Dictionary<int, Test> slotMaper = new Dictionary<int, Test>();
            int xAxis = 0;
            int yAxis = 0;
            for (int i = 1; i < 25; i++)
            {
                slotMaper.Add(i, new Test() { i = xAxis, j = yAxis });
                if (i % 4 == 0)
                {
                    xAxis++;
                    yAxis = 0;
                }
                else
                {
                    yAxis++;
                }
            }
            var test = slotMaper[this.slotId];
            Console.WriteLine($"{test.i}{test.j}");
            if (Schdule.X[test.i][test.j].Id == 0)
            {
                ErrorMessageForOverlapping = string.Empty;
                Schdule.X[test.i][test.j].Id = slotId;
                Schdule.X[test.i][test.j].LecName = lecturerName;
                Schdule.X[test.i][test.j].CourseName = courseName;
                ClassIds.Add(courseId);
            }
            else
            {
                ErrorMessageForOverlapping = "Course Overlapping";
            }

        }

        public void RemoveCourse(MouseEventArgs e)
        {
            Console.WriteLine($"{e.ToString()} the value");
        }

        public async Task Register()
        {
            var result = await registrationBlazorService.AddRegistration(Student.Id, ClassIds);
            Console.WriteLine(result);
            if (result == true)
            {
                IsRegSuccessed = true;
            }
        }

        public void test1(int slotid)
        {
            ClassIds.Remove(ClassIds.Count - 1);
            
        }

       
    }

    public class Test
    {
        public int i { get; set; }
        public int j { get; set; }
    }
}
