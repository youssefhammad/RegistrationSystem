using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Registration.Server.Core.IConfiguration;
using Registration.Server.Services.IService;

namespace Registration.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAdminService _adminService;

        public AdminController(IUnitOfWork unitOfWork,IAdminService adminService)
        {
            _unitOfWork = unitOfWork;
            _adminService = adminService;
        }

        
        [HttpGet("GetAdminById")]
        public async Task<IActionResult> GetAdminById(int id)
        {
            var admin = await _unitOfWork.Admins.GetById(id);
            return Ok(admin);
        }


        
        [HttpGet("GetAdminByUserId")]
        public async Task<IActionResult> GetAdminByUserId(string userId)
        {
            var admin = await _adminService.GetAdminByUserId(userId);
            return Ok(admin);
        }
    }
}
