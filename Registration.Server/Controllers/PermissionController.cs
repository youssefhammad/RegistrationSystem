using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Registration.Server.Core.IConfiguration;
using Registration.Server.DTOs;
using Registration.Server.Services.IService;
using Registration.Shared.Models;

namespace Registration.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PermissionController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IPermissionService _permissionService;

        public PermissionController(IUnitOfWork unitOfWork,
            IPermissionService permissionService)
        {
            _unitOfWork = unitOfWork;
            _permissionService = permissionService;
        }
       
        [HttpGet("GetLastPermissionTime")]
        public async Task<IActionResult> GetLastPermissionTime()
        {
            var result = await _permissionService.GetLastPermissionTime();
            return Ok(result);
        }
      
        [HttpPost("AddNewTimePermisssion")]
        public async Task<IActionResult> AddNewTimePermisssion([FromBody] PostPermissionDto entity)
        {
            var result = await _unitOfWork.Permissions.AddNewTimePermisssion(entity);
            await _unitOfWork.CompleteAsync();
            return Ok(result);
        }
    }
}
