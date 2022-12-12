using Registration.Server.DTOs;
using Registration.Shared.Models;

namespace Registration.Server.Services.IService
{
    public interface IPermissionService
    {
        public Task<PermissionDto> GetLastPermissionTime();
    }
}
