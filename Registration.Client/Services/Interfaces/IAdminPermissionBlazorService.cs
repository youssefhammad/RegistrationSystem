using Registration.Client.BlazorDto;
using Registration.Shared.Models;

namespace Registration.Client.Services.Interfaces
{
    public interface IAdminPermissionBlazorService
    {
        Task<PermissionDto> GetLastPermissionTime();
        Task<bool> AddNewTimePermisssion(PostPermissionDto entity);
        Task<Admin> GetAdminByUserId(string userId);
    }
}
