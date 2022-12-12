using Microsoft.AspNetCore.Components;
using Registration.Client.BlazorDto;
using Registration.Client.Schedule;
using Registration.Client.Services.Interfaces;

namespace Registration.Client.Pages
{
    public partial class Studentviewschdule
    {
        [Parameter]
        public int StudentId { get; set; }
        [Inject]
        public SchduleDto Schdule { get; set; }
        [Inject]
        public IStudentschedBlazorService StudentschedBlazorService { get; set; }
        public PermissionDto permissionDto { get; set; }
        public List<StudentSchduleView> StudentSchduleViewCourses { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
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
            catch(Exception e)
            {
                Console.WriteLine(e);
            }

            permissionDto = (await StudentschedBlazorService.GetLastPermissionTime());
            var startdate = permissionDto.StartDate;
            var enddate = permissionDto.EndDate;
            Console.WriteLine(permissionDto.AdminName.ToString());
            StudentSchduleViewCourses = (await StudentschedBlazorService.ViewSchedule
                (StudentId, startdate, enddate)).ToList();
            Console.WriteLine(StudentSchduleViewCourses.Count);

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

            foreach(var studsched in StudentSchduleViewCourses)
            {
                var slotid = studsched.DayTimelotId;
                var slotidMapped = slotMaper[slotid];
                Schdule.X[slotidMapped.i][slotidMapped.j].Id = slotid;
                Schdule.X[slotidMapped.i][slotidMapped.j].CourseName = studsched.CourseName;
                Schdule.X[slotidMapped.i][slotidMapped.j].LecName = studsched.LecturerName;
            }
        }

        

    }
    public class Mapper
    {
        public int i { get; set; }
        public int j { get; set; }
    }
}
