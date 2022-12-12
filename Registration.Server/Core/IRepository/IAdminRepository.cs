using Registration.Shared.Models;

namespace Registration.Server.Core.IRepository
{
    public interface IAdminRepository : IGenericRepository<Admin>
    { 
        Task<Admin> GetAdminByUserId(string userId);
    }
}
