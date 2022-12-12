using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Registration.Server.Core.IConfiguration;
using Registration.Server.Services.IService;
using Registration.Shared.Models;

namespace Registration.Server.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IUnitOfWork _unitOfWork;

        public StudentController(IStudentService studentService,
            IUnitOfWork unitOfWork)
        {
            _studentService = studentService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]        
        public async Task<IActionResult> Get()
        {
            var users = await _studentService.All();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var item = await _studentService.GetById(id);

            if (item == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(item);
            }
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(int id)
        {
            var res = await _studentService.Delete(id);
            await _unitOfWork.CompleteAsync();
            return res;
            
        }

        [HttpGet("GetStudentByUserID")]
        public async Task<IActionResult> GetStudentByUserId(string userId)
        {
            var student = await _studentService.GetStudentByUserID(userId);
            return Ok(student);
        }


    }
}
