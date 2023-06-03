using Microsoft.AspNetCore.Mvc;
using Registration.Server.Core.IConfiguration;
using Registration.Server.Services.IService;

namespace Registration.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IUnitOfWork _unitOfWork;

        public CourseController(ICourseService courseService,
            IUnitOfWork unitOfWork)
        {
            _courseService = courseService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _courseService.All();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {
            var item = await _courseService.GetById(id);

            if (item == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(item);
            }
        }

    }
}
