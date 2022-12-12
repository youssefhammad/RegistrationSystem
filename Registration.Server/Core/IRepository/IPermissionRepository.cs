using Registration.Server.DTOs;
using Registration.Shared.Models;

namespace Registration.Server.Core.IRepository
{
    public interface IPermissionRepository : IGenericRepository<Permission>
    {
        Task<Permission> GetLastPermissionTime();
        Task<bool> AddNewTimePermisssion(PostPermissionDto entity);
    }
}
