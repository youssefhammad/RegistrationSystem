using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Registration.Server.Core.IConfiguration;
using Registration.Server.Services.IService;

namespace Registration.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
   
    public class RegistrationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IRegistrationService _registrationService;

        public RegistrationController(IUnitOfWork unitOfWork,
            IRegistrationService registrationService)
        {
            _unitOfWork = unitOfWork;
            _registrationService = registrationService;
        }

        [HttpGet("GetListOfFinishedCourses")]
        public async Task<IActionResult> GetListOfFinishedCourses(int studentid)
        {
            var courses = await _registrationService.GetListOfFinishedCourses(studentid);
            return Ok(courses);
        }

        [HttpGet("GetListOfAllCourses")]
        public async Task<IActionResult> GetListOfAllCourses()
        {
            var courses = await _registrationService.GetListOfAllCourses();
            return Ok(courses);
        }

        [HttpGet("GetListOfUNFinishedCourses")]
        public async Task<IActionResult> GetListOfUNFinishedCourses(int studentid)
        {
            var unfinishedCourses = await _registrationService.GetListOfUNFinishedCourses(studentid);
            return Ok(unfinishedCourses);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var users = await _unitOfWork.Registrations.GetById(id);
            return Ok(users);
        }

        [HttpGet("GetListOfAvailableCourses")]
        public async Task<IActionResult> GetListOfAvailableCourses(int studentid)
        {
            var AvailableCourses = await _registrationService.GetListOfAvailableCourses(studentid);
            return Ok(AvailableCourses);
        }

        [HttpGet("GetLecturerListOFCourse")]
        public async Task<IActionResult> GetLecturerListOFCourse(int courseId)
        {
            var lecturer = await _registrationService.GetLecturerListOFCourse(courseId);
            return Ok(lecturer);
        }

        [HttpGet("GetDaySlotByCourseAndLecturer")]
        public async Task<IActionResult> GetDaySlotByCourseAndLecturer(int courseid,
            int lecturerid)
        {
            var result = await _registrationService.GetDaySlotByCourseAndLecturer(courseid, lecturerid);
            return Ok(result);
        }

        [HttpGet("GetLectrurerCourseID")]
        public async Task<IActionResult> GetLectrurerCourseID(int coursid,
            int lectrurerid, int slotperdayId)
        {
            var id = await _registrationService.GetLectrurerCourseID(coursid, lectrurerid, slotperdayId);

            return Ok(id);
        }

                
        [HttpPost("AddRegistration")]
        public async Task<IActionResult> AddRegistration(int studentId,
            [FromBody] List<int> CoursePerLecturerIds)
        {
            bool IsvalidCh = await _registrationService.
                GetListOfCreditHoursForSelectedCourses(CoursePerLecturerIds);
            if (IsvalidCh == false)
            {
                return BadRequest("The maximum CreditHours to register should be less than 18");
            }

            foreach (var CoursePerLecturerId in CoursePerLecturerIds)
            {
                bool IsValid = await _registrationService.CheckCapacity
                    (CoursePerLecturerId);
                if(IsValid == false)
                {
                    return BadRequest("Class capacity is full");
                    
                }
            }

            List<int> timeSplotsIds = await _registrationService.
                CheckTimeConflict(CoursePerLecturerIds);
            bool res = await _registrationService.
                CheckTimeConflictStage2(timeSplotsIds);
            if (res == false)
            {
                return BadRequest("There is Time Overlapping in schdule");
            }
            else
            {
                var result = await _registrationService.
                    AddRegistration(studentId, CoursePerLecturerIds);
                await _unitOfWork.CompleteAsync();
                return Ok(result);
            }
        }

        [HttpGet("ViewSchedule")]
        public async Task<IActionResult> ViewSchedule
            (int studentid, DateTime startdate,DateTime enddate)
        {
            var result = await _registrationService.ViewSchedule(studentid, startdate, enddate);
            return Ok(result);
        }
    }
}
