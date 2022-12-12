using Registration.Server.Core.IConfiguration;
using Registration.Server.DTOs;
using Registration.Server.Services.IService;

namespace Registration.Server.Services.Service
{
    public class PermissionService : IPermissionService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PermissionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<PermissionDto> GetLastPermissionTime()
        {
            var permission = await _unitOfWork.Permissions.GetLastPermissionTime();
            PermissionDto permissionDto = new PermissionDto()
            {
                StartDate = permission.StartDate,
                EndDate = permission.EndDate,
                AdminName = permission.Admin.FullName,
            };

            return permissionDto;
        }
    }
}
