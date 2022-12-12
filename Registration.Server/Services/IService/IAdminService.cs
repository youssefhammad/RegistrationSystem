using Registration.Shared.Models;

namespace Registration.Server.Services.IService
{
    public interface IAdminService
    {
        Task<Admin> GetAdminByUserId(string userId);
    }
}
