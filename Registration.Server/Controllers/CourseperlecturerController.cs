using Microsoft.AspNetCore.Mvc;
using Registration.Server.Core.IConfiguration;
using Registration.Server.Services.IService;

namespace Registration.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseperlecturerController : Controller
    {
        private readonly ICoursePerLecturerService _courseService;
        private readonly IUnitOfWork _unitOfWork;

        public CourseperlecturerController(ICoursePerLecturerService courseService,
            IUnitOfWork unitOfWork)
        {
            _courseService = courseService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet("GetDayAndSlot")]
        public async Task<IActionResult> GetDayAndSlot(int courseId, int LecturerId)
        {
            var result = await _courseService.GetDayAndSlot(courseId, LecturerId);
            return Ok(result);
        }

        [HttpGet("GetInfoByCourseLecId")]
        public async Task<IActionResult> GetInfoByCourseLecId(int courseLecId)
        {
            var result = await _courseService.GetInfoByCourseLecId(courseLecId);
            return Ok(result);
        }
    }
}
